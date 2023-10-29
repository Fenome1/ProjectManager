using Newtonsoft.Json;

namespace ProjectManager.API.Models;

public class Priority
{
    public int IdPriority { get; set; }

    public string Name { get; set; } = null!;

    public string HexCode { get; set; } = null!;

    [JsonIgnore] public virtual ICollection<Objective> Objectives { get; set; } = new List<Objective>();
}