﻿namespace ProjectManager.API.Models;

public class User
{
    public int IdUser { get; set; }

    public int IdRole { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? Image { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Objective> IdObjectives { get; set; } = new List<Objective>();
}