using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace ProjectManager.Desktop.Models;

public partial class Column : ObservableObject
{
    [ObservableProperty] [JsonProperty("IdColorNavigation")]
    private Color? _color;

    [ObservableProperty] private int _idBoard;

    [ObservableProperty] private int _idColumn;

    [ObservableProperty] private string _name = null!;

    [ObservableProperty] private ObservableCollection<Objective>? _objectives;
}