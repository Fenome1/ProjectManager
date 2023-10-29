using System;
using System.Globalization;
using System.Windows.Data;

namespace ProjectManager.Desktop.View.Convertors;

public class DescriptionToToolTipTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var description = (string)value;

        if (string.IsNullOrEmpty(description))
            description = "Агенство";

        return description;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}