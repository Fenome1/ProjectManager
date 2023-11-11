using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Create;
using static ProjectManager.Desktop.ViewModels.Manager.ManagerViewModel;

namespace ProjectManager.Desktop.View.Manager.UserControls;

public partial class ColumnItemControl : UserControl
{
    public ColumnItemControl()
    {
        InitializeComponent();
    }

    private async void CreateNewTask_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var idColumn = (DataContext as Column)?.IdColumn;

        if (idColumn is null) return;

        var createObjectiveDialogWindow = new CreateObjectDialogWindow("Создать задачу");
        createObjectiveDialogWindow.ShowDialog();

        if (!createObjectiveDialogWindow.DialogResult!.Value) return;

        var objectiveName = createObjectiveDialogWindow.EnteredText.Trim();

        if (!string.IsNullOrEmpty(objectiveName))
            await ObjectiveService.CreateAsync((int)idColumn, objectiveName);
    }

    private void SettingsButton_OnClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var contextMenu = button.ContextMenu;

        if (contextMenu != null)
        {
            contextMenu.PlacementTarget = button;
            contextMenu.IsOpen = true;
        }
    }

    private async void SettingContextMenu_OnLoaded(object sender, RoutedEventArgs e)
    {
        var settingContextMenu = sender as ContextMenu;

        var currentColumn = settingContextMenu.DataContext as Column;

        if (currentColumn is null)
            return;

        if (settingContextMenu == null) return;

        var colorMenuItem = settingContextMenu.Items
            .OfType<MenuItem>()
            .FirstOrDefault(item => item.Header != null && item.Header.ToString() == "Цвет");

        if (colorMenuItem is null)
            return;

        colorMenuItem.Items.Clear();

        var colors = await ColorService.GetColorsAsync();

        if (colors is null || !colors.Any())
        {
            MessageBox.Show("Ошибка инициализации цветов");
            return;
        }

        foreach (var color in colors)
        {
            var menuItem = new MenuItem
            {
                Header = color.Name,
                Command = ManagerVm.ColumnColorUpdateCommand,
                CommandParameter = (currentColumn.IdColumn, color.IdColor),
                Background = (SolidColorBrush)new BrushConverter().ConvertFrom(color.HexCode)
            };

            colorMenuItem.Items.Add(menuItem);
        }
    }
}