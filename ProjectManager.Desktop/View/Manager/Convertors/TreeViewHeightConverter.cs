using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProjectManager.Desktop.View.Manager.Convertors;

public class TreeViewHeightConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double gridAgencyHeight) return gridAgencyHeight - 105;

        return DependencyProperty.UnsetValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}