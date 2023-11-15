using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectManager.Desktop.Common.Config.Manager;
using ProjectManager.Desktop.Models;
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
        await ManagerVm.LoadTreeAsync();

        if (ManagerVm.User is null)
        {
            MessageBox.Show("Ошибка авторизации");
            Close();
        }

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
    }
}