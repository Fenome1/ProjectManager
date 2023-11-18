using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProjectManager.Desktop.View.Convertors;

public class ObjectivesBorderHeightConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double boardHeight) return boardHeight / 2 - 50;

        return DependencyProperty.UnsetValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}