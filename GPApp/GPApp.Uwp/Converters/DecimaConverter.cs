using System;
using Windows.UI.Xaml.Data;

namespace GPApp.Uwp.Converters
{
    public class DecimaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            decimal.TryParse(value.ToString(), out decimal valor);
            return valor;
        }
    }
}
