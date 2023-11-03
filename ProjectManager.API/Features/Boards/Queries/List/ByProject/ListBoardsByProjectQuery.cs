using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Queries.List.ByProject;

public class ListBoardsByProjectQuery : BaseQuery<List<Board>>
{
    public ListBoardsByProjectQuery(int idProject, bool isDeleted)
    {
        IdProject = idProject;
        IncludeDeleted = isDeleted;
    }

    public int IdProject { get; set; }
}