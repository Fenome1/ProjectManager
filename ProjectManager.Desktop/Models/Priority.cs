using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectManager.Desktop.Models;

public class Priority
{
    public int IdPriority { get; set; }
    public string Name { get; set; } = null!;
    public string HexCode { get; set; } = null!;
}