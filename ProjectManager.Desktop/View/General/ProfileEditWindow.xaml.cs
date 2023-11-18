using System.Windows;
using static ProjectManager.Desktop.ViewModels.General.ProfileEditViewModel;


namespace ProjectManager.Desktop.View.General;

public partial class ProfileEditWindow : Window
{
    public ProfileEditWindow()
    {
        DataContext = ProfileEditVM;
        InitializeComponent();
    }
}