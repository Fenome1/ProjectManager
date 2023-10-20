using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Queries.List;

public class ListBoardsQuery : IRequest<List<Board>>
{
}