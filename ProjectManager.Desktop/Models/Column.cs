using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Edit;

namespace ProjectManager.Desktop.Models;

public partial class Column : ObservableObject
{
    [ObservableProperty] [JsonProperty("IdColorNavigation")]
    private Color? _color;

    [ObservableProperty] private int _idBoard;

    [ObservableProperty] private int _idColumn;

    [ObservableProperty] private string _name = null!;

    [ObservableProperty] private ObservableCollection<Objective>? _objectives;

    public ICommand DeleteColumnCommand => new RelayCommand(async () =>
    {
        var isDeleteQuestion = MessageBox.Show("Удалить колонку?", "Удаление", MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        if (isDeleteQuestion == MessageBoxResult.Yes)
            await ColumnService.DeleteAsync(IdColumn);
    });

    public ICommand UpdateColumnCommand => new RelayCommand(async () =>
    {
        var columnUpdateWindow = new ColumnUpdateWindow(this);
        columnUpdateWindow.ShowDialog();

        if (!(bool)columnUpdateWindow.DialogResult!)
            return;

        await ColumnService.UpdateAsync(IdColumn, name: columnUpdateWindow.NameTextBox.Text);
    });
}