using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagoVista.Core.PlatformSupport;

namespace LagoVista.Common.WPF.PlatformSupport
{
    public class Storage : LagoVista.Core.PlatformSupport.IStorageService
    {
        public Task ClearKVP(string key)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> Get(Uri rui)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> Get(Locations location, string fileName, string folder = "")
        {
            throw new NotImplementedException();
        }

        public Task<TObject> GetAsync<TObject>(string fileName) where TObject : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetKVPAsync<T>(string key, T defaultValue = null) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasKVPAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<Uri> StoreAsync(Stream stream, Locations location, string fileName, string folder = "")
        {
            throw new NotImplementedException();
        }

        public Task StoreAsync<TObject>(TObject instance, string fileName) where TObject : class
        {
            throw new NotImplementedException();
        }

        public Task StoreKVP<T>(string key, T value) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
