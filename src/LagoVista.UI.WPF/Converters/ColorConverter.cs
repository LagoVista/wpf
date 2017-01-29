using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LagoVista.WPF.UI
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.String)
            {
                Int64 colorValue;
                switch (((string)value).ToLower())
                {
                    case "red": colorValue = 0xFF0000; break;
                    case "green": colorValue = 0x007F00; break;
                    case "blue": colorValue = 0x00007F; break;
                    case "yellow": colorValue = 0xFFFF00; break;
                    case "white": colorValue = 0xFFFFFF; break;
                    case "black": colorValue = 0x000000; break;
                    default:
                        colorValue = System.Convert.ToInt32((value as string).Substring(1), 16);
                        break;
                }
                var a = System.Convert.ToByte((colorValue >> 24) & 0xFF);
                if (a == 0) a = 0xFF;
                var r = System.Convert.ToByte((colorValue >> 16) & 0xFF);
                var g = System.Convert.ToByte((colorValue >> 8) & 0xFF);
                var b = System.Convert.ToByte(colorValue & 0xFF);

                return new SolidColorBrush(Color.FromArgb(a, r, g, b));
            }
            else if (value is LagoVista.Core.Models.Drawing.Color)
            {
                return new SolidColorBrush(ColorFactory.GetColor(value as LagoVista.Core.Models.Drawing.Color));
            }
            else 
            {
                return Brushes.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}