using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace LagoVista.Core.WpfSupport.Test
{
    [TestClass]
    public class StorageTests
    {
        public class Model1
        {
            public String Field1 { get; set; }
            public String Field2 { get; set; }
        }

        [TestMethod]
        public async Task Storage_Should_Save_And_Load_File()
        {
            var model1 = new Model1()
            {
                 Field1 = "Field1Data",
                 Field2 = "Field2Data",
            };

            var storage = new WPF.PlatformSupport.StorageService();
            await storage.StoreAsync(model1,"model1.json");

            var loadedModel = storage.GetAsync<Model1>("model1.json");

            Assert.AreEqual(model1.Field1, model1.Field1);
            Assert.AreEqual(model1.Field2, model1.Field2);
        }
    }
}
