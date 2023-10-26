using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.ViewModels.MainWindowViewModel;

namespace ProjectManager.Desktop.View;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = Instance;

        var _ = new SignalRClient().Start();
    }

    private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        await Instance.LoadAgenciesAsync();
    }

    private async void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var selectedItem = ((TreeView)sender).SelectedItem;

        if (selectedItem is Agency agency)
        {
            await agency.LoadProjectsAsync();

            TabControlVisibilityHider(BoardsTabControl);
        }

        if (selectedItem is Project project)
        {
            await project.LoadBoardsAsync();

            if (project.Boards is null || !project.Boards.Any())
            {
                TabControlVisibilityHider(BoardsTabControl);
                return;
            }

            Instance.SelectedProject = project;
            BoardsTabControl.SelectedIndex = 0;
            BoardsTabControl.Visibility = Visibility.Visible;

            await LoadProjectTree(project);
        }
    }


    private static void TabControlVisibilityHider(TabControl control)
    {
        if (control.Visibility == Visibility.Visible)
            control.Visibility = Visibility.Collapsed;
    }

    private void CloseWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Close();
    }

    private void HideWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void DragWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void WindowSizeChange_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }
}