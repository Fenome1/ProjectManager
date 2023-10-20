using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Commands;

public class UpdateBoardCommand : IRequest<Board>
{
    public int IdBoard { get; set; }
    public string? Name { get; set; }
    public int? IdPriority { get; set; }
    public DateTime? DeadLine { get; set; }
    public bool IsDeadlineReset { get; set; } = false;
}