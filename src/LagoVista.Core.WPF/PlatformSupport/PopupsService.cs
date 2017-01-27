using LagoVista.Core.PlatformSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LagoVista.Core.WPF.PlatformSupport
{
    public class PopupsService : IPopupServices
    {
        public Task<bool> ConfirmAsync(string title, string prompt)
        {
            var tcs = new System.Threading.Tasks.TaskCompletionSource<bool>();

            Task.Run(() =>
            {
                var result = MessageBox.Show(prompt, title, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
                tcs.SetResult(result);
            });

            return tcs.Task;
        }

        public Task<decimal?> PromptForDecimalAsync(string label,  decimal? defaultvalue = 0, string help = "", bool isRequried = false)
        {
            var tcs = new TaskCompletionSource<Decimal?>();
            var promptWindow = new UI.PromptDialog<decimal>();
            promptWindow.Title = label;
            promptWindow.Help = help;
            promptWindow.isRequired = isRequried;
            promptWindow.DecimalVaue = defaultvalue;
            promptWindow.Show();
            promptWindow.Closed += (sndr, args) =>
            {
                tcs.SetResult(promptWindow.DecimalVaue);
            };
            return tcs.Task;
        }

        public Task<int?> PromptForIntAsync(string label, int? defaultvalue = 0, string help = "", bool isRequried = false)
        {
            var tcs = new TaskCompletionSource<int?>();
            var promptWindow = new UI.PromptDialog<int>();
            promptWindow.Title = label;
            promptWindow.Help = help;
            promptWindow.isRequired = isRequried;
            promptWindow.IntValue = defaultvalue;
            promptWindow.Show();
            promptWindow.Closed += (sndr, args) =>
            {
                tcs.SetResult(promptWindow.IntValue);
            };

            return tcs.Task;
        }

        public Task<string> PromptForStringAsync(string label, string defaultvalue = "", string help = "", bool isRequried = false)
        {
            var tcs = new TaskCompletionSource<string>();
            var promptWindow = new UI.PromptDialog<string>();
            promptWindow.Title = label;
            promptWindow.Help = help;
            promptWindow.isRequired = isRequried;
            promptWindow.StringValue = defaultvalue;
            promptWindow.Show();
            promptWindow.Closed += (sndr, args) =>
            {
                tcs.SetResult(promptWindow.StringValue);
            };

            return tcs.Task;
        }

        public Task ShowAsync(string message)
        {
            var tcs = new System.Threading.Tasks.TaskCompletionSource<object>();

            Task.Run(() =>
            {
                MessageBox.Show(message);
                tcs.SetResult(null);
            });

            return tcs.Task;
        }

        public Task ShowAsync(string title, string message)
        {
            var tcs = new System.Threading.Tasks.TaskCompletionSource<object>();

            Task.Run(() =>
            {
                MessageBox.Show(message, title);
                tcs.SetResult(null);
            });

            return tcs.Task;
        }

        public Task<string> ShowOpenFileAsync(string fileMask = "")
        {
            throw new NotImplementedException();
        }

        public Task<string> ShowSaveFileAsync(string defaultFileName = "", string fileMask = "")
        {
            throw new NotImplementedException();
        }
    }
}
