using LagoVista.Core.PlatformSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagoVista.Core.Models;
using System.Collections.ObjectModel;

namespace LagoVista.Core.WPF.PlatformSupport
{
    public class DeviceManager : IDeviceManager
    {
        public ObservableCollection<SerialPortInfo> GetSerialPortsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
