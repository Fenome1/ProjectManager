using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectManager.Desktop.Common.Config.Manager;
using ProjectManager.Desktop.Common.Handlers;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.View.General;
using ProjectManager.Desktop.ViewModels.General;
using static ProjectManager.Desktop.ViewModels.Manager.ManagerViewModel;

namespace ProjectManager.Desktop.View.Manager;

public partial class ManagerWindow : Window
{
    private readonly SignalRManagerClient _signalRManagerClient;

    public ManagerWindow()
    {
        InitializeComponent();
        DataContext = ManagerVm;
        _signalRManagerClient = new SignalRManagerClient();
    }

    private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        var currentUser = ManagerVm.User;

        if (currentUser is null)
        {
            MessageBox.Show("Ошибка авторизации");
            Close();
        }

        ThemeHandler.InitTheme(currentUser.Theme);

        await ManagerVm.LoadTreeAsync();

        await _signalRManagerClient.StartConnection();
    }

    private void TreeViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var selectedItem = ((TreeView)sender).SelectedItem;

        if (selectedItem is Agency agency)
        {
            FrameworkVisibilityHider(BoardsTabControl);

            ManagerVm.SelectedAgency = agency;

            SelectedAgencyBoard.Visibility = Visibility.Visible;
        }

        if (selectedItem is Project project)
        {
            FrameworkVisibilityHider(SelectedAgencyBoard);

            ManagerVm.SelectedProject = project;

            BoardsTabControl.Visibility = Visibility.Visible;

            BoardsTabControl.SelectedIndex = 0;
        }
    }

    private static void FrameworkVisibilityHider(FrameworkElement element)
    {
        if (element.Visibility == Visibility.Visible)
            element.Visibility = Visibility.Collapsed;
    }

    //win control
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

    private async void ManagerWindow_OnClosed(object? sender, EventArgs e)
    {
        await _signalRManagerClient.StopConnection();
        ManagerVm.Dispose();
    }

    private void LoginTextBlock_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var profileEditWindow = new ProfileEditWindow();
        ProfileEditViewModel.ProfileEditVM.User = (User)ManagerVm.User.Clone();
        profileEditWindow.ShowDialog();
    }

    private void ExitButton_OnClick(object sender, RoutedEventArgs e)
    {
        new AuthWindow().Show();
        Close();
    }
}