using System.Collections.Concurrent;
using System.Net.Http;
using System.Windows.Media.Imaging;

public static class AsyncImageLoader
{
    private static readonly HttpClient HttpClient = new();
    private static readonly ConcurrentDictionary<string, BitmapImage> Cache = new();

    public static async Task<BitmapImage> LoadImageAsync(string uri)
    {
        if (Cache.TryGetValue(uri, out var cachedImage)) return cachedImage;

        try
        {
            var response = await HttpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = stream;
            bitmap.EndInit();
            bitmap.Freeze();

            Cache[uri] = bitmap;
            return bitmap;
        }
        catch
        {
            return null;
        }
    }
}