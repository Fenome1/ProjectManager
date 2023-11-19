using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Models.Enums;

namespace ProjectManager.Desktop.View.Convertors;

public class UserImageConverter : IValueConverter
{
    private const string PrimaryImagePath = "pack://application:,,,/Assets/Images/PrimaryTheme/user.png";
    private const string SecondaryImagePath = "pack://application:,,,/Assets/Images/SecondaryTheme/user.png";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var user = value as User;

        if (user is null)
            return null;

        if (user.Image is null)
            return LoadImageFromPath(user.Theme == (int)Themes.Primary ? PrimaryImagePath : SecondaryImagePath);

        return LoadImageFromBytes(user.Image);

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    private BitmapImage LoadImageFromBytes(byte[] imageData, double cropFactor = 0.65)
    {
        var image = new BitmapImage();
        using var stream = new MemoryStream(imageData);
        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.StreamSource = stream;
        image.EndInit();
        image.Freeze();

        var croppedWidth = (int)(image.PixelWidth * cropFactor);
        var croppedHeight = (int)(image.PixelHeight * cropFactor);

        var sourceRect = new Int32Rect(
            (image.PixelWidth - croppedWidth) / 2,
            (image.PixelHeight - croppedHeight) / 2,
            croppedWidth,
            croppedHeight);

        var croppedBitmap = new CroppedBitmap(image, sourceRect);

        return LoadImageFromBitmapFrame(BitmapFrame.Create(croppedBitmap));
    }

    private BitmapImage LoadImageFromPath(string imagePath)
    {
        var image = new BitmapImage();
        image.BeginInit();
        image.UriSource = new Uri(imagePath);
        image.EndInit();
        image.Freeze();
        return image;
    }

    private BitmapImage LoadImageFromBitmapFrame(BitmapFrame frame)
    {
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(frame);

        var image = new BitmapImage();
        using var stream = new MemoryStream();

        encoder.Save(stream);
        stream.Seek(0, SeekOrigin.Begin);

        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.StreamSource = stream;
        image.EndInit();
        image.Freeze();

        return image;
    }
}