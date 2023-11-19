using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectManager.API.Models;

public partial class Agency
{
    public int IdAgency { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
