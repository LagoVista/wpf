using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagoVista.Core.PlatformSupport;
using Newtonsoft.Json;
using System.Net.Http;

namespace LagoVista.Core.WPF.PlatformSupport
{
    public class Storage : LagoVista.Core.PlatformSupport.IStorageService
    {
        Dictionary<String, Object> _kvpStorage;

        private async Task<Dictionary<string, object>> GetDictionary()
        {
            if (_kvpStorage != null)
                return _kvpStorage;

            _kvpStorage = await GetAsync<Dictionary<string, object>>("KVPSTORAGE.DAT");

            return _kvpStorage;
        }


        public async Task ClearKVP(string key)
        {
            (await GetDictionary()).Clear();
        }

        public Task<Stream> Get(Uri uri)
        {
            var client = new HttpClient();
            return client.GetStreamAsync(uri);
        }

        public Task<Stream> Get(Locations location, string fileName, string folder = "")
        {
            throw new NotImplementedException();
        }

        public Task<TObject> GetAsync<TObject>(string fileName) where TObject : class
        {
            if(System.IO.File.Exists(fileName))
            {
                var json = System.IO.File.ReadAllText(fileName);
                var instance = JsonConvert.DeserializeObject<TObject>(json);

                return Task.FromResult(instance);
            }
            else
            {
                return Task.FromResult(default(TObject));
            }
        }

        public async Task<T> GetKVPAsync<T>(string key, T defaultValue = null) where T : class
        {
            var dictionary = await GetDictionary();
            if(dictionary.ContainsKey(key))
            {
                return dictionary[key] as T;
            }
            else
            {
                return defaultValue;
            }
        }

        public async Task<bool> HasKVPAsync(string key)
        {
            var dictionary = await GetDictionary();
            return (dictionary.ContainsKey(key));
        }

        public Task<Uri> StoreAsync(Stream stream, Locations location, string fileName, string folder = "")
        {
            throw new NotImplementedException();
        }

        public Task StoreAsync<TObject>(TObject instance, string fileName) where TObject : class
        {
            var json = JsonConvert.SerializeObject(instance);
            System.IO.File.WriteAllText(fileName, json);

            return Task.FromResult(default(object));
        }

        public async Task StoreKVP<T>(string key, T value) where T : class
        {
            var dictionary = await GetDictionary();
            if(dictionary.ContainsKey(key))
            {
                dictionary.Remove(key);
            }

            dictionary.Add(key, value);
            
        }
    }
}
