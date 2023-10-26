using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop.Models;

public partial class Column : ObservableObject
{
    [ObservableProperty] private List<Objective> _objectives;
    public int IdColumn { get; set; }
    public string Name { get; set; } = null!;
    public int IdBoard { get; set; }
    public int IdColor { get; set; }

    public async Task LoadObjectivesAsync()
    {
        var objectives = await ObjectiveService.GetObjectivesByColumnIdAsync(IdColumn);
        Objectives = objectives;
    }
}