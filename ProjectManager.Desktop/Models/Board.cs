using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Create;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Edit;

namespace ProjectManager.Desktop.Models;

public partial class Board : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Column>? _columns;
    [ObservableProperty] private int _idBoard;
    [ObservableProperty] private int _idProject;
    [ObservableProperty] private string _name = null!;

    public ICommand CreateNewBoardCommand => new RelayCommand(async () =>
    {
        var createBoardDialogWindow = new CreateObjectDialogWindow("Создать доску");
        createBoardDialogWindow.ShowDialog();

        if (!createBoardDialogWindow.DialogResult!.Value) return;

        var boardName = createBoardDialogWindow.EnteredText.Trim();

        if (!string.IsNullOrEmpty(boardName))
            await BoardService.CreateAsync(IdProject, boardName);
    });

    public ICommand UpdateBoardCommand => new RelayCommand(async () =>
    {
        var columnUpdateWindow = new BoardUpdateWindow(this);
        columnUpdateWindow.ShowDialog();

        if (!(bool)columnUpdateWindow.DialogResult!)
            return;

        await BoardService.UpdateAsync(IdBoard, columnUpdateWindow.NameTextBox.Text);
    });

    public ICommand DeleteBoardCommand => new RelayCommand(async () => { await BoardService.DeleteAsync(IdBoard); });
}