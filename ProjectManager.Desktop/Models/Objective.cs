using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace ProjectManager.Desktop.Models;

public partial class Objective : ObservableObject
{
    [ObservableProperty] private DateTime? _deadline;

    [ObservableProperty] private string? _description;

    [ObservableProperty] private int _idColumn;
    [ObservableProperty] private int _idObjective;

    [ObservableProperty] private string _name = null!;

    [JsonProperty("IdPriorityNavigation")] [ObservableProperty]
    private Priority? _priority;

    [ObservableProperty] private bool _status;
}