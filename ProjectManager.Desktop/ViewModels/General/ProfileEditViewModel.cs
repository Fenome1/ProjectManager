using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.ViewModels.Base;
using System.Windows.Input;
using ProjectManager.Desktop.Common.Handlers;
using ProjectManager.Desktop.Models.Enums;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop.ViewModels.General;

public partial class ProfileEditViewModel : ViewModelBase
{
    public static ProfileEditViewModel ProfileEditVM = new();

    [ObservableProperty] private User _user;

    public ProfileEditViewModel()
    {
        ProfileEditVM = this;
    }

    public ICommand ThemeChangeCommand => new RelayCommand(async () =>
    {
        var currentTheme = (Themes) User.Theme;

        currentTheme = currentTheme is Themes.Primary ? Themes.Secondary : Themes.Primary;

        await ThemeManager.SetThemeAsync(User, currentTheme);
    });
}