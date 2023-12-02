using System.Text.Json.Serialization;

namespace ProjectManager.API.Models;

public class User
{
    public int IdUser { get; set; }

    public int Role { get; set; }

    public string Login { get; set; } = null!;

    [JsonIgnore] public string HashedPassword { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public byte[]? Image { get; set; }

    public int Theme { get; set; }

    public bool IsDeleted { get; set; }

    [JsonIgnore] public virtual Role RoleNavigation { get; set; } = null!;

    [JsonIgnore] public virtual Theme ThemeNavigation { get; set; } = null!;

    public virtual ICollection<Objective> IdObjectives { get; set; } = new List<Objective>();
}