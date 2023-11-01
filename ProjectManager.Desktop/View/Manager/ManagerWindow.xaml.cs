using System.Linq;
using System.Threading.Tasks;
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

    private async void TreeViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var selectedItem = ((TreeView)sender).SelectedItem;

        if (selectedItem is Agency) 
            TabControlVisibilityHider(BoardsTabControl);


        if (selectedItem is Project project)
        {
            await project.LoadBoardsAsync();

            if (project.Boards is null || !project.Boards.Any())
            {
                TabControlVisibilityHider(BoardsTabControl);
                return;
            }

            Instance.SelectedProject = project;

            BoardsTabControl.Visibility = Visibility.Visible;

            BoardsTabControl.SelectedIndex = 0;

            await LoadProjectTree(project);
        }
    }

    private static void TabControlVisibilityHider(TabControl control)
    {
        if (control.Visibility == Visibility.Visible)
            control.Visibility = Visibility.Collapsed;
    }

    //theme change
    private void TestThemeSwitchButton_OnClick(object sender, RoutedEventArgs e)
    {
        ChangeTheme();
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
}