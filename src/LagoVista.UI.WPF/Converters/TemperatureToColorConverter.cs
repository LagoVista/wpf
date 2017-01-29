using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace LagoVista.WPF.UI
{
    public class TemperatureToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {

            var warm = 80.0;
            var cold = 32.0;

            var temperature = System.Convert.ToDouble(value);

            if (temperature == 0)
                return new SolidColorBrush(Colors.Transparent);

            var deltaFromCold = temperature - cold;

            var percentDelta = deltaFromCold / (warm - cold);

            if (percentDelta <= 0)
                return Colors.Blue;

            if(percentDelta > 1)
                return Colors.Red;

            var rValue = (byte)(Math.Min(255.0, (percentDelta * 255.0)));
            var bValue = (byte)(Math.Min(255.0, ((1.0 - percentDelta) * 255.0)));

            return Color.FromArgb(0xFF, rValue, 0, bValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new NotImplementedException();
        }
    }
}
