using System;
using System.Threading.Tasks;
using System.Windows;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Models.Enums;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop.Common.Handlers;

public static class ThemeManager
{
    private static readonly string _themePath = "/View/Styles/Themes";

    public static async Task SetThemeAsync(User user, Themes theme)
    {
        var path = _themePath;

        switch (theme)
        {
            case Themes.Primary:
                path += "/PrimaryThemeDictionary.xaml";
                user.Theme = (int)Themes.Primary;
                break;
            case Themes.Secondary:
                path += "/SecondaryThemeDictionary.xaml";
                user.Theme = (int)Themes.Secondary;
                break;
        }

        await UserService.UpdateAsync(user.IdUser, theme: user.Theme);

        var resourceDict = Application.LoadComponent(new Uri(path, UriKind.Relative)) as ResourceDictionary;
        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(resourceDict);
    }

    public static void InitTheme(int theme)
    {
        var path = _themePath;
        switch ((Themes)theme)
        {
            case Themes.Primary:
                path += "/PrimaryThemeDictionary.xaml";
                break;
            case Themes.Secondary:
                path += "/SecondaryThemeDictionary.xaml";
                break;
        }

        var resourceDict = Application.LoadComponent(new Uri(path, UriKind.Relative)) as ResourceDictionary;
        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(resourceDict);
    }
}