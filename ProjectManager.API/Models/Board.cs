using System.Text.Json.Serialization;

namespace ProjectManager.API.Models;

public class Board
{
    public int IdBoard { get; set; }

    public string Name { get; set; } = null!;

    public int IdProject { get; set; }

    public virtual ICollection<Column> Columns { get; set; } = new List<Column>();
    [JsonIgnore]
    public virtual Project IdProjectNavigation { get; set; } = null!;
}