using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.ViewModels;

namespace ProjectManager.Desktop.View;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = MainWindowViewModel.Instance;

        var _ = new SignalRClient().Start();
    }

    private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        await MainWindowViewModel.Instance.LoadAgenciesAsync();
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

            MainWindowViewModel.Instance.SelectedProject = project;
            BoardsTabControl.SelectedIndex = 0;
            BoardsTabControl.Visibility = Visibility.Visible;
        }
    }

    private static void TabControlVisibilityHider(TabControl control)
    {
        if (control.Visibility == Visibility.Visible)
            control.Visibility = Visibility.Collapsed;
    }

    private async void BoardsTabControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = ((TabControl)sender).SelectedItem;

        if (selectedItem is Board board) await board.LoadColumnsAsync();
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