using System;
using System.Collections.Generic;

namespace ProjectManager.API.Models;

public partial class ObjectiveAssignment
{
    public int IdAssignment { get; set; }

    public int IdObjective { get; set; }

    public int IdAssigneel { get; set; }

    public virtual User IdAssigneelNavigation { get; set; } = null!;

    public virtual Objective IdObjectiveNavigation { get; set; } = null!;
}
