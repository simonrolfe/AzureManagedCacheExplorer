
namespace AzureCacheExplorer.Credentials
{
    public interface ICredentialsPersistence
    {
        CacheCredentials Load();

        void Save(CacheCredentials credentials);
    }
}
