﻿using Newtonsoft.Json;

namespace ProjectManager.API.Models;

public class Objective
{
    public int IdObjective { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int IdColumn { get; set; }

    public int? IdPriority { get; set; }

    public DateTime? Deadline { get; set; }

    public bool Status { get; set; }
    [JsonIgnore] public virtual Column IdColumnNavigation { get; set; } = null!;
    [JsonIgnore] public virtual Priority? IdPriorityNavigation { get; set; }
    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
}