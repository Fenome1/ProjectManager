using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectManager.Desktop.Models;

public partial class Board : ObservableObject
{
    public string Name { get; set; } = null!;

    public int IdProject { get; set; }

    public int? IdPriority { get; set; }

    public DateTime? Deadline { get; set; }
}