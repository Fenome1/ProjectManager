using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Models.Enums;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop.Models;

public partial class User : ObservableObject

{
    [ObservableProperty] private string? _fullname;

    [ObservableProperty] private ObservableCollection<Objective>? _idObjectives;
    [ObservableProperty] private int _idUser;

    [ObservableProperty] private byte[]? _image;

    [ObservableProperty] private string _login = null!;

    [ObservableProperty] private int _role;

    [ObservableProperty] private int _theme;

    public ICommand AssignUserCommand => new RelayCommand<object>(async parameter =>
    {
        var checkBox = parameter as CheckBox;

        if (checkBox is null)
            return;

        var user = checkBox.DataContext as User;

        if (user is null)
            return;

        var idObjective = (int)checkBox.Tag;

        if (checkBox.IsChecked.Value)
        {
            await UserService.UpdateAssignAsync(user.IdUser, idObjective, Operation.Add);
            return;
        }

        await UserService.UpdateAssignAsync(user.IdUser, idObjective, Operation.Delete);
    });
}