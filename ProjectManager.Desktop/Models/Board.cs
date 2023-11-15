using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Create;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Edit;
using ProjectManager.Desktop.ViewModels.Manager;
using static ProjectManager.Desktop.ViewModels.Manager.ManagerViewModel;

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

    public ICommand DeleteBoardCommand => new RelayCommand(async () => {

        var boardCount = ManagerVm.Agencies
        .SelectMany(a => a.Projects)
        .SelectMany(p => p.Boards)
        .Count();

        if (boardCount <= 1)
        {
            MessageBox.Show("Невозможно удалить последнюю доску",
                "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return;
        }

        await BoardService.DeleteAsync(IdBoard); 
    });
}