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
        RegVM.Dispose();
    }

    private async void ComboBox_Loaded(object sender, RoutedEventArgs e)
    {
        await RegVM.LoadRolesAsync();
    }

    private async void RegButton_Click(object sender, RoutedEventArgs e)
    {
        if (await RegVM.RegisterAsync())
        {
            PasswordBox.Password = "";
            ConfirmPasswordBox.Password = "";
            RolesComboBox.SelectedIndex = 0;

            MessageBox.Show("Успешная регистрация", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}