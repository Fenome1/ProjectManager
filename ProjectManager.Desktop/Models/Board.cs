using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectManager.Desktop.Models;

public class Board : ObservableObject
{
    public string Name { get; set; } = null!;

    public int IdProject { get; set; }
}