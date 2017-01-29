using System;
using System.Globalization;
using System.Windows.Data;

namespace LagoVista.WPF.UI
{
    public class EnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (value == null)
                return false;

            if (parameter == null)
            {
                return !String.IsNullOrEmpty(value.ToString());
            }
            else
            {
                var minLength = System.Convert.ToInt32(parameter);
                return value.ToString().Length >= Math.Max(1, minLength);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new NotImplementedException();
        }
    }
}
