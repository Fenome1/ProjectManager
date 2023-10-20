using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Queries.Get;

public class GetBoardQuery : IRequest<Board>
{
    public int IdBoard { get; set; }
}