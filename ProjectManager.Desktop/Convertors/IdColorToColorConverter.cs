using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace ProjectManager.Desktop.Convertors;

public class IdColorToColorConverter : IValueConverter
{
    private string DefaultColor => "#FF8D83DA";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var idColor = (int)value;
        var currentColor = App.BorderColors.FirstOrDefault(c => c.IdColor == idColor);

        var resultHexCode = currentColor?.HexCode ?? DefaultColor;
        return (Color)ColorConverter.ConvertFromString(resultHexCode);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}