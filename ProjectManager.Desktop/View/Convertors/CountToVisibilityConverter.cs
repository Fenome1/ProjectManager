using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProjectManager.Desktop.View.Convertors;

public class CountToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var count = (int)value;

        return count switch
        {
            0 => Visibility.Visible,
            _ => Visibility.Collapsed
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}