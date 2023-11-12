using System;
using System.Globalization;
using System.Windows.Data;

namespace ProjectManager.Desktop.View.Manager.Convertors;

public class StatusToOpacityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var status = (bool)value;
        return status switch
        {
            true => 0.7,
            _ => 1
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}