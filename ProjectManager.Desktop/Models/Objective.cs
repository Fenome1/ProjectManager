using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectManager.Desktop.Models;

public class Objective : ObservableObject
{
    public int IdObjective { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int IdColumn { get; set; }

    public int? IdPriority { get; set; }

    public DateTime? Deadline { get; set; }
}