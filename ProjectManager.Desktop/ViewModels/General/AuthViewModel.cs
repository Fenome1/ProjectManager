using System;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Models.Enums;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Executor;
using ProjectManager.Desktop.View.Manager;
using ProjectManager.Desktop.ViewModels.Base;
using ProjectManager.Desktop.ViewModels.Executor;
using ProjectManager.Desktop.ViewModels.Manager;

namespace ProjectManager.Desktop.ViewModels.General;

public partial class AuthViewModel : ViewModelBase, IDisposable
{
    public static AuthViewModel AuthVm = new();

    [ObservableProperty] private string _login = "Fenome1";
    [ObservableProperty] private string _password = "pass";

    public AuthViewModel()
    {
        AuthVm = this;
    }

    public ICommand LoginInCommand => new RelayCommand(async () =>
    {
        if (string.IsNullOrWhiteSpace(Login) ||
            string.IsNullOrWhiteSpace(Password))
        {
            MessageBox.Show("Необходимо заполнить все поля");
            return;
        }

        var user = await UserService.AuthAsync(Login, Password);

        if (user is null)
        {
            MessageBox.Show("Неверный логин или пароль");
            return;
        }

        OpenAppropriateWindow(user);
    });

    public void Dispose()
    {
        Login = "";
        Password = "";

        GC.SuppressFinalize(true);
    }

    private void OpenAppropriateWindow(User user)
    {
        Window newWindow = null;

        switch (user.Role)
        {
            case (int)Roles.Manager:
                newWindow = new ManagerWindow();
                ManagerViewModel.ManagerVm.User = user;
                break;
            case (int)Roles.Executor:
                newWindow = new ExecutorWindow();
                ExecutorViewModel.ExecutorVm.User = user;
                break;
        }

        newWindow.Show();

        Application.Current.MainWindow.Close();
    }
}