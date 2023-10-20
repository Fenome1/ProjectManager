using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Commands;

public class DeleteBoardCommand : IRequest<Board>
{
    public int IdBoard { get; set; }
}