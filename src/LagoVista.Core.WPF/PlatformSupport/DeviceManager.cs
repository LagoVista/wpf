﻿using LagoVista.Core.PlatformSupport;
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
        public ISerialPort CreateSerialPort(SerialPortInfo portInfo)
        {            
            return new SerialPort();
        }

        public  Task<ObservableCollection<SerialPortInfo>> GetSerialPortsAsync()
        {
            var ports = new ObservableCollection<SerialPortInfo>();
            foreach (var port in System.IO.Ports.SerialPort.GetPortNames())
            {
                ports.Add(new SerialPortInfo()
                {
                    Id = port,
                    Name = port,
                });
            }

            return Task.FromResult(ports);
        }
    }
}
