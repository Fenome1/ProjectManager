using System;
using System.Collections.Generic;

namespace ProjectManager.API.Models;

public partial class User
{
    public int IdUser { get; set; }

    public int Role { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Image { get; set; }

    public int Theme { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Role RoleNavigation { get; set; } = null!;

    public virtual Theme ThemeNavigation { get; set; } = null!;

    public virtual ICollection<Objective> IdObjectives { get; set; } = new List<Objective>();
}
