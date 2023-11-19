using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Models.Enums;
using static ProjectManager.Desktop.ViewModels.General.ProfileEditViewModel;


namespace ProjectManager.Desktop.View.General;

public partial class ProfileEditWindow : Window
{
    public ProfileEditWindow()
    {
        DataContext = ProfileEditVM;
        InitializeComponent();
    }

    private void DragWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void HideWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void CloseWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Close();
    }

    private void ThemeCheckBox_OnLoaded(object sender, RoutedEventArgs e)
    {
        var checkBox = (CheckBox)sender;

        checkBox.IsChecked = (Themes)ProfileEditVM.User.Theme != Themes.Primary ;
    }
}