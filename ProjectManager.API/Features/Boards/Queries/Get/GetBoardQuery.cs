using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Queries.Get;

public class GetBoardQuery : BaseQuery<Board>
{
    public GetBoardQuery(int idBoard, bool isDeleted)
    {
        IdBoard = idBoard;
        IncludeDeleted = isDeleted;
    }

    public int IdBoard { get; set; }
}