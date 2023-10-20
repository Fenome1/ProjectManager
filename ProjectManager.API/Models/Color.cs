using System;
using System.Collections.Generic;

namespace ProjectManager.API.Models;

public partial class Color
{
    public int IdColor { get; set; }

    public string Name { get; set; } = null!;

    public string HexCode { get; set; } = null!;

    public virtual ICollection<Column> Columns { get; set; } = new List<Column>();
}
