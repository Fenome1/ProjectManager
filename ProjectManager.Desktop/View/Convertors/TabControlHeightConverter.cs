using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProjectManager.Desktop.View.Convertors;

public class TabControlHeightConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double tabControlHeight) return tabControlHeight - 155;

        return DependencyProperty.UnsetValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}