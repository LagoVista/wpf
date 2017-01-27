using LagoVista.Core.PlatformSupport;
using System;
using System.Threading.Tasks;
using LagoVista.Core.Models;
using System.IO;

namespace LagoVista.Core.WPF.PlatformSupport
{
    public class SerialPort : ISerialPort
    {
        System.IO.Ports.SerialPort _serialPort;

        public bool IsConnected
        {
            get
            {
                lock (this)
                {
                    if (_serialPort == null)
                    {
                        return false;
                    }

                    return _serialPort.IsOpen;
                }
            }
        }

        public Task CloseAsync()
        {
            Dispose();
            return Task.FromResult(default(object));
        }

        public void Dispose()
        {
            lock (this)
            {

                { }
                if (_serialPort != null)
                {
                    if (_serialPort.IsOpen)
                        _serialPort.Close();

                    _serialPort.Dispose();
                    _serialPort = null;
                }
            }
        }

        public Task<Stream> OpenAsync(SerialPortInfo serialPortInfo)
        {
            try
            {
                lock (this)
                {
                    _serialPort = new System.IO.Ports.SerialPort(serialPortInfo.Id, serialPortInfo.BaudRate);
                    _serialPort.Open();

                    return Task.FromResult(_serialPort.BaseStream);
                }
            }
            catch (Exception)
            {
                _serialPort = null;
                return Task.FromResult(default(Stream));
            }
        }
    }
}
