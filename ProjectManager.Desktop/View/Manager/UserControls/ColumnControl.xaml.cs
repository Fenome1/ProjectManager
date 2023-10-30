using System.Windows.Controls;
using System.Windows.Input;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Create;

namespace ProjectManager.Desktop.View.Manager.UserControls;

public partial class ColumnControl : UserControl
{
    public ColumnControl()
    {
        InitializeComponent();
    }

    private async void CreateNewColumn_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var idBoard = (DataContext as Board)?.IdBoard;

        if (idBoard is null) return;

        var createColumnDialogWindow = new CreateObjectDialogWindow();
        createColumnDialogWindow.ShowDialog();

        if (!createColumnDialogWindow.DialogResult!.Value) return;

        var columnName = createColumnDialogWindow.EnteredText.Trim();

        if (!string.IsNullOrEmpty(columnName))
            await ColumnService.CreateColumnAsync((int)idBoard, columnName);
    }
}