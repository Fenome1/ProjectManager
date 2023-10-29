using Newtonsoft.Json;

namespace ProjectManager.API.Models;

public class Board
{
    public int IdBoard { get; set; }

    public string Name { get; set; } = null!;

    public int IdProject { get; set; }

    [JsonIgnore] public virtual ICollection<Column> Columns { get; set; } = new List<Column>();

    [JsonIgnore] public virtual Project IdProjectNavigation { get; set; } = null!;
}