using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Commands;

public class CreateBoardCommand : IRequest<Board>
{
    public int IdProject { get; set; }
    public string Name { get; set; } = null!;
}