using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Create;

namespace ProjectManager.Desktop.Models;

public partial class Objective : ObservableObject
{
    [ObservableProperty] private DateTime? _deadline;

    [ObservableProperty] private string? _description;

    [ObservableProperty] private int _idColumn;
    [ObservableProperty] private int _idObjective;

    [ObservableProperty] private string _name = null!;

    [JsonProperty("IdPriorityNavigation")]
    [ObservableProperty]
    private Priority? _priority;

    [ObservableProperty] private bool _status;

    public ICommand DeleteObjectiveCommand => new RelayCommand(async () =>
    {
        await ObjectiveService.DeleteAsync(IdObjective);
    });
}