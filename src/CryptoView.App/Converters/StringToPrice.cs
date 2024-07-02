using System.Globalization;
using System.Windows.Data;

namespace CryptoView.App.Converters;

class StringToPrice : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string str && decimal.TryParse(str, out decimal result))
        {
            return "$" + string.Format(CultureInfo.CurrentCulture, "{0:N3}", result);
        }
        return 0m;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}