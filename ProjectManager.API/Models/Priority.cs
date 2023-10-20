﻿using System;
using System.Collections.Generic;

namespace ProjectManager.API.Models;

public partial class Priority
{
    public int IdPrioriy { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Board> Boards { get; set; } = new List<Board>();

    public virtual ICollection<Objective> Objectives { get; set; } = new List<Objective>();
}
