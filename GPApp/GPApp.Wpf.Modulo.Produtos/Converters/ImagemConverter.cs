using GPApp.Shared.Helpers;
using System;
using System.Globalization;
using System.Windows.Data;

namespace GPApp.Wpf.Modulo.Produtos.Converters
{
    public class ImagemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var base64 = value.ToString();
            return ImagemHelper.Base64ToBytes(base64);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
