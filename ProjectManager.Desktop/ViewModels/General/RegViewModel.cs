using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManager.Desktop.ViewModels.Base;

namespace ProjectManager.Desktop.ViewModels.General;

public partial class RegViewModel : ViewModelBase
{
    [ObservableProperty] private string _login;

    [ObservableProperty] private string _password;

    [ObservableProperty] private string _passwordConfirm;

    public RegViewModel()
    {
        RegVM = this;
    }

    public static RegViewModel RegVM { get; private set; } = new();
}