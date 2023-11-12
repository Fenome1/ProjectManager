using System;
using System.Collections.Generic;

namespace ProjectManager.API.Models;

public partial class Project
{
    public int IdProject { get; set; }

    public string Name { get; set; } = null!;

    public int IdAgency { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Board> Boards { get; set; } = new List<Board>();

    public virtual Agency IdAgencyNavigation { get; set; } = null!;
}
