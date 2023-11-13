using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectManager.API.Models;

public partial class Board
{
    public int IdBoard { get; set; }

    public string Name { get; set; } = null!;

    public int IdProject { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Column> Columns { get; set; } = new List<Column>();

    [JsonIgnore] public virtual Project IdProjectNavigation { get; set; } = null!;
}
