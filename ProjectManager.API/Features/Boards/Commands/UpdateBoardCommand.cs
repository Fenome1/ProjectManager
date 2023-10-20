using MediatR;
using ProjectManager.API.Models;

public class UpdateBoardCommand : IRequest<Board>
{
    public int IdBoard { get; set; }
    public string? Name { get; set; }
    public int? IdPriority { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}