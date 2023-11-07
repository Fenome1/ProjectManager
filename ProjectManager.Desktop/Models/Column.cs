using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop.Models;

public partial class Column : ObservableObject
{
    [ObservableProperty] [JsonProperty("IdColorNavigation")]
    private Color? _color;

    [ObservableProperty] private int _idBoard;

    [ObservableProperty] private int _idColumn;

    [ObservableProperty] private string _name = null!;

    [ObservableProperty] private ObservableCollection<Objective>? _objectives;

    public ICommand DeleteColumnCommand => new RelayCommand(async () => { await ColumnService.DeleteAsync(IdColumn); });
}