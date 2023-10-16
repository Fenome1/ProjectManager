namespace ProjectManager.Core.Models;

public partial class Agency
{
    public int IdAgency { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
