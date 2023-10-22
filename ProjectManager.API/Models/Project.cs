using System.Text.Json.Serialization;

namespace ProjectManager.API.Models;

public class Project
{
    public int IdProject { get; set; }

    public string Name { get; set; } = null!;

    public int IdAgency { get; set; }

    public virtual ICollection<Board> Boards { get; set; } = new List<Board>();

    [JsonIgnore]
    public virtual Agency IdAgencyNavigation { get; set; } = null!;
}