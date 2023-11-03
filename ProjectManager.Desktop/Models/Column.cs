using System.Collections.Generic;
using System.Threading.Tasks;
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
    [ObservableProperty] private List<Objective>? _objectives;

    public async Task LoadObjectivesAsync()
    {
        /*var objectives = await ObjectiveService.GetObjectivesByColumnIdAsync(IdColumn);
        Objectives = objectives;*/
    }
}