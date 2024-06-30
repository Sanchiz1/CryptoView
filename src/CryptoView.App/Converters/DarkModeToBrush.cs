using CryptoView.App.Stores;
using System.Globalization;
using System.Windows.Data;

namespace CryptoView.App.Converters;
internal class DarkModeToBrush : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (parameter is string pipeDelimitedColors)
        {
            var colors = pipeDelimitedColors.Split('|');
            return DarkModeStore.Store.IsDarkMode ? colors[1] : colors[0];
        }
        return "#FCFF00";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}