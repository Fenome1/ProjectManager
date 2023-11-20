using System.Text;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Common.Handlers;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Models.Enums;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.General;
using ProjectManager.Desktop.ViewModels.Base;

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
        var currentTheme = (Themes)User.Theme;

        currentTheme = currentTheme is Themes.Primary ? Themes.Secondary : Themes.Primary;

        await ThemeManager.SetThemeAsync(User, currentTheme);
    });

    public ICommand SaveProfileDataCommand => new RelayCommand(async () =>
    {
        var newLogin = User.Login;
        var newFirstName = User.FirstName;
        var newLastName = User.LastName;

        var sb = new StringBuilder();

        if (!string.IsNullOrEmpty(newLogin))
        {
            if (!await UserService.UpdateAsync(User.IdUser, newLogin))
                sb.AppendLine("Такой логин уже существует");
        }
        else
        {
            sb.AppendLine("Логин не может быть пустым");
        }

        if (!string.IsNullOrEmpty(newFirstName))
            await UserService.UpdateAsync(User.IdUser, firstName: newFirstName);
        else
            sb.AppendLine("Имя не может быть пустым");

        if (!string.IsNullOrEmpty(newLastName))
            await UserService.UpdateAsync(User.IdUser, lastName: newLastName);
        else
            sb.AppendLine("Фамилия не может быть пустой");

        if (sb.Length > 0)
            MessageBox.Show(sb.ToString(), "Ошибка при сохранении данных", MessageBoxButton.OK, MessageBoxImage.Error);
        else
            MessageBox.Show("Данные успешно сохранены", "Изменение профиля", MessageBoxButton.OK,
                MessageBoxImage.Information);
    });

    public ICommand DeleteUserProfileCommand => new RelayCommand(async () =>
    {
        var doProfileDeleteMessageBox = MessageBox.Show("Удалить профиль?",
            "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (doProfileDeleteMessageBox == MessageBoxResult.Yes)
        {
            await UserService.DeleteAsync(User.IdUser);

            var windows = Application.Current.Windows;

            new AuthWindow().Show();

            for (var i = 0; i < windows.Count; i++) windows[i].Close();
        }
    });
}