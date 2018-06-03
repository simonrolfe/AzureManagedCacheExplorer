using System;

namespace AzureCacheExplorer.Credentials
{
    [Serializable]
    public class CacheCredential : IEquatable<CacheCredential>
    {
        public string FriendlyName { get; set; }
        public string EndpointName { get; set; }
        public string AccessKey { get; set; }

        public CacheCredential Copy()
        {
            return new CacheCredential { FriendlyName = this.FriendlyName, EndpointName = this.EndpointName, AccessKey = this.AccessKey };
        }

        public bool Equals(CacheCredential other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }

            if(this.FriendlyName != other.FriendlyName)
            {
                return false;
            }
            if(this.AccessKey != other.AccessKey)
            {
                return false;
            }
            if(this.EndpointName != other.EndpointName)
            {
                return false;
            }
            return true;
        }

        public static bool operator == (CacheCredential a, CacheCredential b)
        {
            if(object.ReferenceEquals(a, null))
            {
                if(object.ReferenceEquals(b, null))
                {
                    return true;
                }
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator != (CacheCredential a, CacheCredential b)
        {
            if (object.ReferenceEquals(a, null))
            {
                if (object.ReferenceEquals(b, null))
                {
                    return false;
                }
                return true;
            }
            return !a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            if(obj is CacheCredential)
            {
                return ((CacheCredential)obj).Equals(this);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (this.AccessKey + this.EndpointName + this.FriendlyName).GetHashCode();
        }
    }
}
