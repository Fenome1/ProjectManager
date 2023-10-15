using System;
using System.Collections.Generic;

namespace ProjectManager.API.Models;

public partial class Board
{
    public int IdBoard { get; set; }

    public string Name { get; set; } = null!;

    public int IdProject { get; set; }

    public int? IdPriority { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<Column> Columns { get; set; } = new List<Column>();

    public virtual Priority? IdPriorityNavigation { get; set; }

    public virtual Project IdProjectNavigation { get; set; } = null!;
}
