using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace GPApp.Uwp.Converters
{
    public class VisibilidadeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var exibir = System.Convert.ToBoolean(value);
            return exibir
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
