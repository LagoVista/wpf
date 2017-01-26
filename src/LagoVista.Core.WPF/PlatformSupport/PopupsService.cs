using LagoVista.Core.PlatformSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LagoVista.Common.WPF.PlatformSupport
{
    public class PopupsService : IPopupServices
    {
        public Task<bool> ConfirmAsync(string title, string prompt)
        {
            var tcs = new System.Threading.Tasks.TaskCompletionSource<bool>();

            Task.Run(() => {
                var result = MessageBox.Show(prompt, title, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
                tcs.SetResult(result);
            });

            return tcs.Task;
        }

        public Task ShowAsync(string message)
        {
            var tcs = new System.Threading.Tasks.TaskCompletionSource<object>();

            Task.Run(() => {
                MessageBox.Show(message);
                tcs.SetResult(null);
            });

            return tcs.Task;
        }

        public Task ShowAsync(string title, string message)
        {
            var tcs = new System.Threading.Tasks.TaskCompletionSource<object>();

            Task.Run(() => {
                MessageBox.Show(message, title);
                tcs.SetResult(null);
            });

            return tcs.Task;
        }
    }
}
