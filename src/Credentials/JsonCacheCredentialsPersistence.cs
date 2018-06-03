using Newtonsoft.Json;
using System;
using System.IO;

namespace AzureCacheExplorer.Credentials
{
    public class JsonCacheCredentialsPersistence : ICredentialsPersistence
    {
        private const string CREDENTIALS_FILE_NAME = "StoredCredentials.json";
        private readonly JsonSerializer _js;

        public JsonCacheCredentialsPersistence()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Error;

            _js = JsonSerializer.Create(settings);
        }

        public CacheCredentials Load()
        {
            CacheCredentials creds = null;

            string fileName = GetFileName();
            if(File.Exists(fileName))
            {
                FileStream stream = File.OpenRead(fileName);
                if (stream != null)
                {
                    StreamReader sr = new StreamReader(stream);
                    using (JsonTextReader jr = new JsonTextReader(sr))  //this will dispose the wrapped StreamReader and stream.
                    {
                        creds = _js.Deserialize<CacheCredentials>(jr);
                    }
                    }
            }

            if (creds == null)
            {
                return new CacheCredentials();
            }
            return creds;
        }

        public void Save(CacheCredentials credentials)
        {
            Directory.CreateDirectory(GetFolderPath());

            FileStream stream = File.OpenWrite(GetFileName());
            StreamWriter sw = new StreamWriter(stream);
            using(JsonTextWriter jw = new JsonTextWriter(sw)) //this will dispose the wrapped StreamWriter and stream.
            {
                _js.Serialize(jw, credentials);
            }
        }

        private string GetFileName()
        {
            return Path.Combine(GetFolderPath(), CREDENTIALS_FILE_NAME);
        }

        private string GetFolderPath()
        {
            string myDocsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(myDocsFolder, "AzureCacheExplorer");
        }
    }
}
