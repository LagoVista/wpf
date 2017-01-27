using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LagoVista.Core.WPF.UI
{
    public class PromptDialog : Window
    {
        public PromptDialog()
        {
            var container = new Grid();

            Content = container;
        }
    }
}
