using System;
using System.Collections.ObjectModel;
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
        try
        {
            if (Password != PasswordConfirm) throw new InvalidOperationException("Пароль и подтверждение не совпадают");

            if (SelectedRole == null || SelectedRole.IdRole == 0)
                throw new InvalidOperationException("Роль не выбрана");

            await UserService.CreateAsync(Login, Password, SelectedRole.IdRole);

            Login = "";

            return true;
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception)
        {
            MessageBox.Show("Произошла ошибка при регистрации", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        return false;
    }
}