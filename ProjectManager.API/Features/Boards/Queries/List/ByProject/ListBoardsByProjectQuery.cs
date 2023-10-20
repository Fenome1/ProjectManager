using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Queries.List.ByProject;

public class ListBoardsByProjectQuery : IRequest<List<Board>>
{
    public int IdProject { get; set; }
}