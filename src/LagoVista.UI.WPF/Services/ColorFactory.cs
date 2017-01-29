using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LagoVista.WPF.UI
{
    public static class ColorFactory
    {
        public static Color GetColor(LagoVista.Core.Models.Drawing.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        } 
    }
}
