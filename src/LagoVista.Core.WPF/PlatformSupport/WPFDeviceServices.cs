using LagoVista.Core;
using LagoVista.Core.IOC;
using LagoVista.Core.PlatformSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace LagoVista.Common.WPF.PlatformSupport
{
    public class WPFDeviceServices
    {
        public static void Init(Dispatcher dispatcher)
        {
            SLWIOC.Register<IDispatcherServices>(new DispatcherServices(dispatcher));
            SLWIOC.Register<IPopupServices>(new PopupsService());
            SLWIOC.Register<IStorageService>(new Storage());
            SLWIOC.Register<ILogger>(new Logger());
            SLWIOC.Register<INetworkService>(new NetworkService());
        }
    }
}
