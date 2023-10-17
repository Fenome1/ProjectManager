using MediatR;

namespace ProjectManager.API.Models;

public class Project : IRequest
{
    public int IdProject { get; set; }

    public string Name { get; set; } = null!;

    public int IdAgency { get; set; }

    public virtual ICollection<Board> Boards { get; set; } = new List<Board>();

    public virtual Agency IdAgencyNavigation { get; set; } = null!;
}