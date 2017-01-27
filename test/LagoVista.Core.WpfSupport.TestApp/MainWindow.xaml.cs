using LagoVista.Core.WPF.PlatformSupport;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            var popup = new PopupsService();
            SaveFileResult.Text = await popup.ShowSaveFileAsync("default.txt", "*.txt");
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StopTimer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartTimer_Click(object sender, RoutedEventArgs e)
        {

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
            var result = (await popup.PromptForDecimalAsync("Get me a decimal", 42.5m));
            if(result.HasValue)
            {
                SetDecimalResult.Text = result.Value.ToString();
            }
            else
            {
                SetDecimalResult.Text = "[null]";
            }
        }
    }
}
