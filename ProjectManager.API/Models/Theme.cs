using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectManager.API.Models;

public partial class Theme
{
    public int IdTheme { get; set; }

    public string Name { get; set; } = null!;

    [JsonIgnore] public virtual ICollection<User> Users { get; set; } = new List<User>();
}
