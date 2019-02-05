using System;
using System.Globalization;
using System.Windows.Data;

namespace GPApp.Wpf.Modulo.Produtos.Converters
{
    public class RealValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal.TryParse(value.ToString(), out decimal valor);
            return valor.ToString("C2", new CultureInfo("pt-BR"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
