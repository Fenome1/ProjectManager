using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace ProjectManager.Desktop.Models;

public class Objective : ObservableObject
{
    public int IdObjective { get; set; }
    public int IdColumn { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool Status { get; set; }
    public DateTime? Deadline { get; set; }
    [JsonProperty("IdPriorityNavigation")] public Priority? Priority { get; set; }
}