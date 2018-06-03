using Microsoft.ApplicationServer.Caching;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AzureCacheExplorer
{
    public class CacheInteractionProgressEventArgs : EventArgs
    {
        public int Progress { get; private set; }

        public CacheInteractionProgressEventArgs(int progress)
        {
            this.Progress = progress;
        }
    }

    public class CacheInteractionStartProgressEventArgs : EventArgs
    {
        public int MaxProgress { get; private set; }
        public CacheInteractionStartProgressEventArgs (int maxProgress)
        {
            this.MaxProgress = maxProgress;
        }
    }

    public class CacheInteractionEndBusyEventArgs : EventArgs
    {

    }

    public class CacheInteractionStartBusyEventArgs : EventArgs
    {
        public string TaskName { get; private set; }

        public CacheInteractionStartBusyEventArgs(string taskName)
        {
            this.TaskName = taskName;
        }
    }


    public class CacheInteraction
    {
        private const string CACHED_KEY_PREFIX = "CACHED_KEY_";
        private const string CACHED_ITEM_KEYS_REGION_NAME = "CachedItemKeys";
        public const string UNVERSIONED_PREFIX = "Unversioned";
        private DataCache _cache;
        private Dictionary<string, List<string>> _versions;
        private List<string> _filteredKeys;
        private bool _hasKeyRegion;
        private MethodInfo _getKeysMethod = null;

        public delegate void CacheInteractionProgressHandler(object sender, CacheInteractionProgressEventArgs e);
        public delegate void CacheInteractionStartProgressHandler(object sender, CacheInteractionStartProgressEventArgs e);
        public delegate void CacheInteractionEndBusyHandler(object sender, CacheInteractionEndBusyEventArgs e);
        public delegate void CacheInteractionStartBusyHandler(object sender, CacheInteractionStartBusyEventArgs e);

        //empty delegates to avoid null checks as these won't be raised often
        public event CacheInteractionProgressHandler CacheInteractionProgress = delegate { };
        public event CacheInteractionStartProgressHandler CacheInteractionStartProgress = delegate { };
        public event CacheInteractionEndBusyHandler CacheInteractionEndBusy = delegate { };
        public event CacheInteractionStartBusyHandler CacheInteractionStartBusy = delegate { };

        public void Connect(int storedCredentialIndex, CredentialsHelper credentialsHelper, string cacheName)
        {
            CacheInteractionStartBusy(this, new CacheInteractionStartBusyEventArgs("Connecting..."));
            DataCacheFactoryConfiguration config = credentialsHelper.GetDataCacheConfiguration(storedCredentialIndex);
            DataCacheFactory fac = new DataCacheFactory(config);

            _cache = fac.GetCache(cacheName);
            CacheInteractionEndBusy(this, new CacheInteractionEndBusyEventArgs());
        }

        public int TotalKeyCount(string Version)
        {
            return _versions[Version].Count();
        }

        public int FilteredKeyCount
        {
            get 
            {
                if(_filteredKeys == null)
                {
                    return 0;
                }
                return _filteredKeys.Count();
            }
        }

        public void Clear()
        {
            _versions = null;
            _cache.Clear();
        }

        private void RefreshKeys()
        {
            CacheInteractionStartBusy(this, new CacheInteractionStartBusyEventArgs("Refreshing cache keys"));
            
            _versions = new Dictionary<string, List<string>>();
            ConcurrentDictionary<string, ConcurrentBag<string>> cacheKeys = new ConcurrentDictionary<string, ConcurrentBag<string>>();
            
            _hasKeyRegion = CheckItemKeysRegion();

            if(_hasKeyRegion)
            {
                Parallel.ForEach(_cache.GetObjectsInRegion(CACHED_ITEM_KEYS_REGION_NAME), cacheKeyName =>
                {
                    KeyValuePair<string, string> versionAndKey = GetVersionAndKey(cacheKeyName.Key);
                    if (!cacheKeys.ContainsKey(versionAndKey.Key))
                    {
                        cacheKeys.TryAdd(versionAndKey.Key, new ConcurrentBag<string>());
                    }

                    cacheKeys[versionAndKey.Key].Add(versionAndKey.Value);
                });
            }
            else
            {

                List<string> regions = new List<string>(64);
                regions.AddRange(_cache.GetSystemRegions());
                
                CacheInteractionStartProgress(this, new CacheInteractionStartProgressEventArgs(regions.Count()));
                int progress = 0;
                foreach(string regionName in regions)
                {
                    //foreach(string cacheKey in GetCacheKeys(regionName))
                    Parallel.ForEach(GetCacheKeys(regionName), cacheKey => 
                    {
                        KeyValuePair<string, string> versionAndKey = GetVersionAndKey(cacheKey);
                        if (!cacheKeys.ContainsKey(versionAndKey.Key))
                        {
                            cacheKeys.TryAdd(versionAndKey.Key, new ConcurrentBag<string>());
                        }

                        cacheKeys[versionAndKey.Key].Add(versionAndKey.Value);
                    });
                    progress++;
                    CacheInteractionProgress(this, new CacheInteractionProgressEventArgs(progress));
                }
                CacheInteractionStartBusy(this, new CacheInteractionStartBusyEventArgs("Refreshing cache keys"));
            }
            
            foreach(string version in cacheKeys.Keys)
            {
                _versions.Add(version, new List<string>(cacheKeys[version]));
            }
            CacheInteractionEndBusy(this, new CacheInteractionEndBusyEventArgs());
        }

        private bool CheckItemKeysRegion()
        {
            return _cache.GetObjectsInRegion(CACHED_ITEM_KEYS_REGION_NAME).Any();
        }

        public void SortKeys(bool SortAscending)
        {
            if(_filteredKeys == null || _filteredKeys.Count == 0)
            {
                return;
            }
            _filteredKeys.Sort();
            if(!SortAscending)
            {
                _filteredKeys.Reverse();
            }
        }

        public void FilterCacheKeyList(string version, string filter = "")
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                _filteredKeys = _versions[version];
            }
            else
            {
                _filteredKeys = _versions[version].AsParallel().Where(x => x.IndexOf(filter, StringComparison.OrdinalIgnoreCase) > -1).ToList();
            }
        }

        public string GetItem(int index)
        {
            return _filteredKeys[index];
        }

        public IEnumerable<string> GetVersions()
        {
            if(_versions == null)
            {
                RefreshKeys();
            }
            return _versions.Keys;
        }

        public void Remove(string version, string key)
        {
            RemoveItem(version, key);
            _versions[version].Remove(key);
            
        }

        private void RemoveItem(string version, string key)
        {
            string versionedKey = GetVersionedKey(version, key);
            _cache.Remove(versionedKey);
            if (_hasKeyRegion)
            {
                string cachedKeyItemKey = string.Format("{0}{1}", CACHED_KEY_PREFIX, versionedKey);
                _cache.Remove(cachedKeyItemKey, CACHED_ITEM_KEYS_REGION_NAME);
            }
        }

        public int ClearVersion(string version)
        {
            CacheInteractionStartBusy(this, new CacheInteractionStartBusyEventArgs(string.Format("Clearing version {0}", version)));
            
            int keyCount = _versions[version].Count;
            
            int removedKeys = 0;
            CacheInteractionStartProgress(this, new CacheInteractionStartProgressEventArgs(keyCount));

            Parallel.ForEach (_versions[version], key =>
            {
                RemoveItem(version, key);
                Interlocked.Increment(ref removedKeys);
                if (removedKeys % 10 == 0)
                {
                    CacheInteractionProgress(this, new CacheInteractionProgressEventArgs(removedKeys));
                }
            });
            CacheInteractionEndBusy(this, new CacheInteractionEndBusyEventArgs());
            RefreshKeys();
            return removedKeys;
        }

        public DataCacheItem GetCacheItem(string version, string key)
        {
            return _cache.GetCacheItem(GetVersionedKey(version, key));
        }

        private string GetVersionedKey(string version, string key)
        {
            if(!_hasKeyRegion || version == "Unversioned")
            {
                return key;
            }
            return version + "-" + key;
        }

        private KeyValuePair<string, string> GetVersionAndKey(string keyName)
        {
            if(_hasKeyRegion && keyName.StartsWith(CacheInteraction.CACHED_KEY_PREFIX))
            {
                keyName = keyName.Substring(CacheInteraction.CACHED_KEY_PREFIX.Length);
            }

            int indexOfDash = keyName.IndexOf('-');

            if (indexOfDash == -1)
            {
                return new KeyValuePair<string, string>("Unversioned", keyName);
            }

            bool possibleVersionOk = true;
            string possibleVersion = keyName.Substring(0, indexOfDash);

            foreach (char c in possibleVersion)
            {
                if (!char.IsNumber(c) && c != '.') //versions only contain numbers and ., so anything else is broken.
                {
                    possibleVersionOk = false;
                    break;
                }
            }

            if (possibleVersionOk)
            {
                return new KeyValuePair<string, string>(possibleVersion, keyName.Substring(keyName.IndexOf('-') + 1));
            }
            
            return new KeyValuePair<string, string>("Unversioned", keyName);
        }

        private IEnumerable<string> GetCacheKeys(string region)
        {
            if(_getKeysMethod == null)
            {
                _getKeysMethod = _cache.GetType().GetMethod("GetKeys", BindingFlags.NonPublic | BindingFlags.Instance);
            }
            
            object[] getKeysParams = new object[] {region};

            return _getKeysMethod.Invoke(_cache, getKeysParams) as IEnumerable<string>;
        }
    }
}
