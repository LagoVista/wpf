using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LagoVista.WPF.UI
{
    public class BoolToSolidBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(ColorFactory.GetColor(value as LagoVista.Core.Models.Drawing.Color));
        }

      
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
