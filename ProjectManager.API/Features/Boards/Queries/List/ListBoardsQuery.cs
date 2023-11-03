using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Queries.List;

public class ListBoardsQuery : BaseQuery<List<Board>>
{
    public ListBoardsQuery(bool isDeleted)
    {
        IncludeDeleted = isDeleted;
    }
}