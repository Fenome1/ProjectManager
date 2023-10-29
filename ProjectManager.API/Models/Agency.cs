using Newtonsoft.Json;

namespace ProjectManager.API.Models;

public class Agency
{
    public int IdAgency { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [JsonIgnore] public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}