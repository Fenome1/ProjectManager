using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Color = ProjectManager.Desktop.Models.Color;

namespace ProjectManager.Desktop.View.Convertors;

public class IdColorToColorConverter : IValueConverter
{
    private string DefaultColor => "#FF8D83DA";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var color = (Color)value;

        var resultHexCode = color?.HexCode ?? DefaultColor;
        return (System.Windows.Media.Color)ColorConverter.ConvertFromString(resultHexCode);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}