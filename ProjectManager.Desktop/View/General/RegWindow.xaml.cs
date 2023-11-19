using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static ProjectManager.Desktop.ViewModels.General.RegViewModel;

namespace ProjectManager.Desktop.View.General;

public partial class RegWindow : Window
{
    public RegWindow()
    {
        InitializeComponent();
        DataContext = RegVM;
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

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        RegVM.Password = ((PasswordBox)sender).Password;
    }

    private void ConfirmPasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        RegVM.PasswordConfirm = ((PasswordBox)sender).Password;
    }

    private void ToAuthButton_OnClick(object sender, RoutedEventArgs e)
    {
        var authWindow = new AuthWindow();
        authWindow.Show();
        Close();
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    }
}