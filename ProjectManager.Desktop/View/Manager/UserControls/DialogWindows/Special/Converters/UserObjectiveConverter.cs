using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using ProjectManager.Desktop.Models;

namespace ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Special.Converters;

public class UserObjectiveConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var user = (User)values[0];
        var idObjective = (int)values[1];

        if (user.IdObjectives is null || idObjective < 0)
            return false;

        return user.IdObjectives.Any(obj => obj.IdObjective == idObjective);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}