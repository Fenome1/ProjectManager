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

        var sq = new SignalRClient();
        sq.Start();
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

    private void TabControlVisibilityHider(TabControl control)
    {
        if (control.Visibility == Visibility.Visible)
            control.Visibility = Visibility.Collapsed;
    }

    private void DragWindow(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }
}