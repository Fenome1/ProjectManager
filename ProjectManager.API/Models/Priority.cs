namespace ProjectManager.API.Models;

public class Priority
{
    public int IdPrioriy { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Objective> Objectives { get; set; } = new List<Objective>();
}