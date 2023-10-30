using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.ViewModels.Manager.ManagerViewModel;

namespace ProjectManager.Desktop.View.Manager;

public partial class ManagerWindow : Window
{
    public ManagerWindow()
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

            await LoadProjectTree(project);

            BoardsTabControl.Visibility = Visibility.Visible;
        }
    }

    private static void TabControlVisibilityHider(TabControl control)
    {
        if (control.Visibility == Visibility.Visible)
            control.Visibility = Visibility.Collapsed;
    }

    private void TestThemeSwitchButton_OnClick(object sender, RoutedEventArgs e)
    {
        ChangeTheme();
    }

    private void CloseWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Close();
    }

    private void DragWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void WindowSizeChange_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }

    private void HideWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
}