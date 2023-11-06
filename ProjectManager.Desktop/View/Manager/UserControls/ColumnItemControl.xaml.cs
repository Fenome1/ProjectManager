﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Create;

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

        var createObjectiveDialogWindow = new CreateObjectDialogWindow();
        createObjectiveDialogWindow.ShowDialog();

        if (!createObjectiveDialogWindow.DialogResult!.Value) return;

        var objectiveName = createObjectiveDialogWindow.EnteredText.Trim();

        if (!string.IsNullOrEmpty(objectiveName))
            await ObjectiveService.CreateObjectiveAsync((int)idColumn, objectiveName);
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var contextMenu = button.ContextMenu;

        if (contextMenu != null)
        {
            contextMenu.PlacementTarget = button;
            contextMenu.IsOpen = true;
        }
    }
}