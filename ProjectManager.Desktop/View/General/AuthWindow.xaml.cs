using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static ProjectManager.Desktop.ViewModels.General.AuthViewModel;

namespace ProjectManager.Desktop.View.General;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
        DataContext = AuthVm;
        Application.Current.MainWindow = this;
    }

    private void DragWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void WindowSizeChange_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized;
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
        AuthVm.Password = ((PasswordBox)sender).Password;
    }

    private void ToRegButton_OnClick(object sender, RoutedEventArgs e)
    {
        var regWindow = new RegWindow();
        regWindow.Show();
        Close();
    }

    private void AuthWindow_Closed(object sender, System.EventArgs e)
    {
        AuthVm.Dispose();
    }
}