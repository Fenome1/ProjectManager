using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop;

public partial class App : Application
{
    static App()
    {
        Initialize();
    }

    public static List<Color> BorderColors { get; set; }

    public static async void Initialize()
    {
        var colors = await ColorService.GetColorsAsync();

        if (!colors.Any())
        {
            MessageBox.Show("Ошибка инициализации: Ошибка загрузка цветов");
            return;
        }

        BorderColors = colors;
    }
}