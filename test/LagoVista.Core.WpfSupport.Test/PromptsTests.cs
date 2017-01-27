using LagoVista.Core.WPF.PlatformSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.Core.WpfSupport.Test
{
    [TestClass]
    public class PromptsTests
    {
        [TestMethod]
        public async Task PromptForDecimal()
        {
            var promptService = new PopupsService();
            await promptService.PromptForDecimalAsync("Get Value");
        }
    }
}