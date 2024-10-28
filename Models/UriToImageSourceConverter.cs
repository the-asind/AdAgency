using System.Globalization;
using System.Windows.Data;

namespace AdAgency.Converters;

public class UriToImageSourceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string uri && Uri.IsWellFormedUriString(uri, UriKind.Absolute))
        {
            var task = Task.Run(() => AsyncImageLoader.LoadImageAsync(uri));
            task.Wait();
            return task.Result;
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}