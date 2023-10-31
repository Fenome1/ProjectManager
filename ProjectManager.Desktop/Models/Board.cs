using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Create;

namespace ProjectManager.Desktop.Models;

public partial class Board : ObservableObject
{
    [ObservableProperty] private List<Column>? _columns;
    public int IdBoard { get; set; }
    public string Name { get; set; } = null!;
    public int IdProject { get; set; }

    public ICommand CreateNewBoardCommand => new RelayCommand(async () =>
    {
        var createBoardDialogWindow = new CreateObjectDialogWindow();
        createBoardDialogWindow.ShowDialog();

        if (!createBoardDialogWindow.DialogResult!.Value) return;

        var boardName = createBoardDialogWindow.EnteredText.Trim();

        if (!string.IsNullOrEmpty(boardName))
            await BoardService.CreateBoardAsync(IdProject, boardName);
    });

    public async Task LoadColumnsAsync()
    {
        var columns = await ColumnService.GetColumnsByBoardIdAsync(IdBoard);
        Columns = columns;
    }
}