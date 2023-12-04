using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.ViewModels.Base;

namespace ProjectManager.Desktop.ViewModels.General;

public partial class RegViewModel : ViewModelBase, IDisposable
{
    [ObservableProperty] private string _login;

    [ObservableProperty] private string _password;

    [ObservableProperty] private string _passwordConfirm;

    [ObservableProperty] private ObservableCollection<Role> _roles = new();

    [ObservableProperty] private Role? _selectedRole;

    public RegViewModel()
    {
        RegVM = this;
    }

    public static RegViewModel RegVM { get; private set; } = new();

    public void Dispose()
    {
        Login = "";
        Password = "";
        PasswordConfirm = "";
        Roles.Clear();

        GC.SuppressFinalize(this);
    }

    public async Task LoadRolesAsync()
    {
        var defaultRole = new Role
        {
            IdRole = 0,
            Name = "Не выбрано"
        };

        Roles.Add(defaultRole);

        var roles = await RoleService.GetRolesAsync();

        if (roles is null)
        {
            MessageBox.Show("Ошибка инициализации ролей");
            return;
        }

        foreach (var role in roles)
            Roles.Add(role);
    }

    public async Task<bool> RegisterAsync()
    {
        if (string.IsNullOrEmpty(Login) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrEmpty(PasswordConfirm))
        {
            ShowError("Не все поля заполнены", "Предупреждение");
            return false;
        }

        if (SelectedRole == null || SelectedRole.IdRole == 0)
        {
            ShowError("Пожалуйста, выберите роль", "Предупреждение");
            return false;
        }

        if (string.IsNullOrWhiteSpace(Login) || Login.Length < 6)
        {
            ShowError("Логин должен состоять минимум из 6 символов", "Предупреждение");
            return false;
        }

        if (string.IsNullOrWhiteSpace(Password) || Password.Length < 6)
        {
            ShowError("Пароль должен состоять минимум из 6 символов", "Предупреждение");
            return false;
        }

        if (Password != PasswordConfirm)
        {
            ShowError("Неверное подтверждение пароля", "Предупреждение");
            return false;
        }

        if (await UserService.IsLoginExistAsync(Login))
        {
            ShowError("Пользователь с таким логином уже существует", "Ошибка");
            return false;
        }

        if (!await UserService.CreateAsync(Login, Password, SelectedRole.IdRole))
        {
            ShowError("Произошла ошибка при регистрации", "Ошибка");
            return false;
        }

        Login = "";

        return true;
    }

    private void ShowError(string message, string caption)
    {
        MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
    }
}