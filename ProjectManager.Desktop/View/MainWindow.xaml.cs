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

    private async void AgencyTree_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
    {
    }

    private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        await MainWindowViewModel.Instance.LoadAgenciesAsync();
    }

    private async void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var agency = ((TreeView)sender).SelectedItem;
        await MainWindowViewModel.Instance.Agencies.First(a => a.IdAgency == ((Agency)agency).IdAgency)
            .LoadProjectsAsync();
    }
}