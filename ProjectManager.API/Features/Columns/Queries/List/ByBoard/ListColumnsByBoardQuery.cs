using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Queries.List.ByBoard;

public class ListColumnsByBoardQuery : BaseQuery<List<Column>>
{
    public ListColumnsByBoardQuery(int idBoard, bool isDeleted)
    {
        IdBoard = idBoard;
        IncludeDeleted = isDeleted;
    }

    public int IdBoard { get; set; }
}