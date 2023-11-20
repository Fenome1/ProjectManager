using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectManager.Desktop.Models;

public class Color
{
    public int IdColor { get; set; }
    public string Name { get; set; } = null!;
    public string HexCode { get; set; } = null!;
}