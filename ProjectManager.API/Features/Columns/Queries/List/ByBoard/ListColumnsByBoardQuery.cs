using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Queries.List.ByBoard;

public class ListColumnsByBoardQuery : IRequest<List<Column>>
{
    public int IdBoard { get; set; }
}