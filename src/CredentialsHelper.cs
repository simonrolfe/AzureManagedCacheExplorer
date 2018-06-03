using AzureCacheExplorer.Credentials;
using Microsoft.ApplicationServer.Caching;
using System.Security;

namespace AzureCacheExplorer
{


    public class CredentialsHelper
    {
        private CacheCredentials _credentials;
        private readonly ICredentialsPersistence _peristence;
        public CacheCredentials Credentials
        {
            get { return _credentials;  }
        }

        public CredentialsHelper()
        {
            _peristence = new JsonCacheCredentialsPersistence();
            Load();
            
        }

        public void Load()
        {
            _credentials = _peristence.Load();
            if(string.IsNullOrWhiteSpace(_credentials.CacheName))
            {
                _credentials.CacheName = "default";
            }
        }

        public void Save()
        {
            _peristence.Save(_credentials);
        }


        /// <summary>
        /// Creates a Secure String for connecting to services from a known string
        /// </summary>
        /// <param name="token">The string to create a Secure String from.</param>
        /// <returns>A read only Secure String, ready for use.</returns>
        private SecureString CreateSecureString(string token)
        {
            SecureString secureString = new SecureString();
            foreach (char c in token)
            {
                secureString.AppendChar(c);
            }
            secureString.MakeReadOnly();
            return secureString;
        }

        public int AddCredential(string friendlyName, string endpointName, string accessKey)
        {
            _credentials.Credentials.Add(new CacheCredential{ AccessKey = accessKey, EndpointName = endpointName, FriendlyName = friendlyName});
            return _credentials.Credentials.Count;
        }

        public void RemoveCredential(int index)
        {
            _credentials.Credentials.Remove(_credentials.Credentials[index]);
        }

        public CacheCredential GetCredential(int index)
        {
            return _credentials.Credentials[index];
        }

        public DataCacheFactoryConfiguration GetDataCacheConfiguration(int index)
        {
            CacheCredential credential = _credentials.Credentials[index];

            return GetDataCacheConfiguration(credential.EndpointName, credential.AccessKey);
        }

        private DataCacheFactoryConfiguration GetDataCacheConfiguration(string endpointString, string accessKey)
        {
            // Setup the DataCacheFactory configuration.
            DataCacheFactoryConfiguration factoryConfig = new DataCacheFactoryConfiguration();
            factoryConfig.AutoDiscoverProperty = new DataCacheAutoDiscoverProperty(true, GetAzureCacheEndpointFromString(endpointString));

            // Setup DataCacheSecurity configuration.
            using (SecureString secureACSKey = CreateSecureString(accessKey))
            {
                DataCacheSecurity factorySecurity = new DataCacheSecurity(secureACSKey, false);
                factoryConfig.SecurityProperties = factorySecurity;
            }

            return factoryConfig;
        }

        private static string GetAzureCacheEndpointFromString(string endpointString)
        {
            if (endpointString.EndsWith(".cache.windows.net"))
            {
                return endpointString;
            }
            else
            {
                return string.Format("{0}.cache.windows.net", endpointString);
            }
            
        }

        
    }
}
