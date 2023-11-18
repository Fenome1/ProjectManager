using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.ViewModels.Base;

namespace ProjectManager.Desktop.ViewModels.General;

public partial class ProfileEditViewModel : ViewModelBase
{
    public static ProfileEditViewModel ProfileEditVM = new();

    [ObservableProperty] private User _editingUser;

    public ProfileEditViewModel()
    {
        ProfileEditVM = this;
    }
}