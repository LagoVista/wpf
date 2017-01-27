using LagoVista.Core.IOC;
using LagoVista.Core.PlatformSupport;
using LagoVista.Core.WPF.PlatformSupport;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LagoVista.Core.WpfSupport.TestApp
{
    /// <summary>
    /// Very Simple and Ugly logic to test out WPF stuff, most if it is User Interface so not a good candiate for Unit Test, eventually I'd like to build some Unit Tests for this
    /// </summary>
    public partial class MainWindow : Window
    {
        ITimer _timer;
        public MainWindow()
        {
            InitializeComponent();
            SLWIOC.RegisterSingleton<IDispatcherServices>(new DispatcherServices(this.Dispatcher));
            SLWIOC.RegisterSingleton<IStorageService>(new StorageService());
        }
        

        private async void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            var popup = new PopupsService();
            var result = await popup.ShowSaveFileAsync("default.txt", "TextFile|*.txt");
            if (!String.IsNullOrEmpty(result))
            {
               SaveFileResult.Text = result;
            }
            else
            {
                SaveFileResult.Text = "null";
            }
        }

        private async void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var popup = new PopupsService();
            var result = await popup.ShowOpenFileAsync();
            if(!String.IsNullOrEmpty(result))
            {
                OpenFileResult.Text = result;
            }
            else
            {
                OpenFileResult.Text = "null";
            }
        }

        private void StopTimer_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            StopTimerResult.Text = "Stopped at " + DateTime.Now.ToString();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            StartTimerResult.Text = DateTime.Now.ToString();
        }

        private void StartTimer_Click(object sender, RoutedEventArgs e)
        {
            var timerFactory = new TimerFactory();
            _timer = timerFactory.Create(TimeSpan.FromSeconds(1));

            _timer.InvokeOnUIThread = true;
            _timer.Tick += _timer_Tick;

            _timer.Start();
        }

        private async void SetString_Click(object sender, RoutedEventArgs e)
        {
            var popup = new PopupsService();
            var result = (await popup.PromptForStringAsync("Get me a string", "Hello World", "This is some help"));
            if (!String.IsNullOrEmpty(result))
            {
                SetStringResult.Text = result;
            }
            else
            {
                SetStringResult.Text = "[empty]";
            }
        }

        private async void SetInt_Click(object sender, RoutedEventArgs e)
        {
            var popup = new PopupsService();
            var result = (await popup.PromptForIntAsync("Get me a int", 42));
            if (result.HasValue)
            {
                SetIntResult.Text = result.Value.ToString();
            }
            else
            {
                SetIntResult.Text = "[null]";
            }
        }

        private async void SetDecimal_Click(object sender, RoutedEventArgs e)
        {
            var popup = new PopupsService();
            var result = (await popup.PromptForDoubleAsync("Get me a decimal", 42.5));
            if(result.HasValue)
            {
                SetDecimalResult.Text = result.Value.ToString();
            }
            else
            {
                SetDecimalResult.Text = "[null]";
            }
        }

        private async void SetDecimalRequired_Click(object sender, RoutedEventArgs e)
        {
            var popup = new PopupsService();
            var result = (await popup.PromptForDoubleAsync("Get me a decimal", null, "You really need help?", true));
            if (result.HasValue)
            {
                SetDecimalResultRequried.Text = result.Value.ToString();
            }
            else
            {
                SetDecimalResultRequried.Text = "[null]";
            }
        }

        private async void GetSerialPorts_Click(object sender, RoutedEventArgs e)
        {
            var portMessage = String.Empty;
            var deviceManager = new DeviceManager();
            var ports = await deviceManager.GetSerialPortsAsync();
            foreach(var port in ports)
            {
                portMessage += port.Name + "; ";
            }

            GetSerialPortResults.Text = portMessage;

        }

        private async void OpenPort_Click(object sender, RoutedEventArgs e)
        {
            var deviceManager = new DeviceManager();
            var ports = await deviceManager.GetSerialPortsAsync();
            var firstPort = ports.First();
            firstPort.BaudRate = 115200;
           

            var port = new SerialPort();
            var portToOpen= await port.OpenAsync(firstPort);
            if(firstPort != null)
            {
                OpenPortResult.Text = firstPort.Name + " is open!";
            }
            else
            {
                OpenPortResult.Text = "Could not open port" + firstPort.Name;
            }

        }

        private void ClosePort_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
