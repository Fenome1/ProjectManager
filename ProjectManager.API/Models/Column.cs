using Newtonsoft.Json;

namespace ProjectManager.API.Models;

public class Column
{
    public int IdColumn { get; set; }

    public string Name { get; set; } = null!;

    public int IdBoard { get; set; }

    public int IdColor { get; set; }

    [JsonIgnore] public virtual Board IdBoardNavigation { get; set; } = null!;

    public virtual Color IdColorNavigation { get; set; } = null!;

    [JsonIgnore] public virtual ICollection<Objective> Objectives { get; set; } = new List<Objective>();
}