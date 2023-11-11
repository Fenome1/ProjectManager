using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Services;
using static ProjectManager.Desktop.ViewModels.Manager.ManagerViewModel;

namespace ProjectManager.Desktop.View.Manager.UserControls;

public partial class ObjectiveItemControl : UserControl
{
    public ObjectiveItemControl()
    {
        InitializeComponent();
    }

    private void OpenContextMenu_OnClick(object sender, RoutedEventArgs e)
    {
        var element = (FrameworkElement)sender;
        var contextMenu = element.ContextMenu;

        if (contextMenu != null)
        {
            contextMenu.PlacementTarget = element;
            contextMenu.IsOpen = true;
        }
    }

    private async void SettingPriorityContextMenu_OnLoaded(object sender, RoutedEventArgs e)
    {
        var settingContextMenu = sender as ContextMenu;

        var currentObjective = settingContextMenu.DataContext as Objective;

        if (currentObjective is null)
            return;

        if (settingContextMenu == null) return;

        var priorityMenuItem = settingContextMenu.Items
            .OfType<MenuItem>()
            .FirstOrDefault(item => item.Header != null && item.Header.ToString() == "Приоритет");

        if (priorityMenuItem is null)
            return;

        priorityMenuItem.Items.Clear();

        var priorities = await PriorityService.GetPrioritiesAsync();

        if (priorities is null || !priorities.Any())
        {
            MessageBox.Show("Ошибка инициализации приоритетов");
            return;
        }

        var defaultItem = new MenuItem
        {
            Header = "Нет",
            Command = ManagerVm.ObjectivePriorityUpdateCommand,

            //Передача параметра -1 в idPriority для того чтобы обработать в комманде, для сброса приоритета, 

            CommandParameter = (currentObjective.IdObjective, -1)
        };

        priorityMenuItem.Items.Add(defaultItem);

        foreach (var priority in priorities)
        {
            var menuItem = new MenuItem
            {
                Header = priority.Name,
                Command = ManagerVm.ObjectivePriorityUpdateCommand,
                CommandParameter = (currentObjective.IdObjective, priority.IdPriority)
            };

            priorityMenuItem.Items.Add(menuItem);
        }
    }
}