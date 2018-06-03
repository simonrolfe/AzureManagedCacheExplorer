using System;
using System.Collections.Generic;

namespace AzureCacheExplorer.Credentials
{
    [Serializable]
    public class CacheCredentials
    {
        public List<CacheCredential> Credentials;

        public int SelectedCredentialIndex{ get; set; } 

        public string CacheName { get; set; } 

        public CacheCredentials()
        {
            Credentials = new List<CacheCredential>();
        }

        public CacheCredentials Copy()
        {
            CacheCredentials credentials = new CacheCredentials();
            credentials.SelectedCredentialIndex = this.SelectedCredentialIndex;
            foreach(CacheCredential cred in this.Credentials)
            {
                credentials.Credentials.Add(cred.Copy());
            }

            return credentials;
        }
    }
}
