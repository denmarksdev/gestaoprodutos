using System;
using Windows.UI.Xaml.Data;

namespace GPApp.Uwp.Converters
{
    public class IntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int.TryParse(value.ToString(), out int valor);
            return valor;
        }
    }
}
