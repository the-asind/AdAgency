using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace AdAgency.Converters;

public class UriToVisibilityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not string uri || !Uri.IsWellFormedUriString(uri, UriKind.Absolute)) return Visibility.Visible;
        try
        {
            var bitmap = new BitmapImage(new Uri(uri));
            return Visibility.Collapsed;
        }
        catch
        {
            // Ignore exceptions and fall back to the default behavior
        }

        return Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}