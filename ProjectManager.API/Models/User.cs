﻿using System.Text.Json.Serialization;

namespace ProjectManager.API.Models;

public class User
{
    public int IdUser { get; set; }

    public int Role { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public byte[]? Image { get; set; } = null;

    public int Theme { get; set; }

    public bool IsDeleted { get; set; }

    [JsonIgnore] public virtual Role RoleNavigation { get; set; } = null!;

    [JsonIgnore] public virtual Theme ThemeNavigation { get; set; } = null!;

    public virtual ICollection<Objective> IdObjectives { get; set; } = new List<Objective>();
}