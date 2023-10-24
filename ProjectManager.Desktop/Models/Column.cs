namespace ProjectManager.Desktop.Models;

public class Column
{
    public int IdColumn { get; set; }
    public string Name { get; set; } = null!;
    public int IdBoard { get; set; }
    public int IdColor { get; set; }
}