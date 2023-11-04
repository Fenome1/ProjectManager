using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Queries.List.ByColumn;

public class ListObjectivesByColumnQuery : BaseQuery<List<Objective>>
{
    public ListObjectivesByColumnQuery(int idColumn, bool isDeleted)
    {
        IdColumn = idColumn;
        IncludeDeleted = isDeleted;
    }

    public int IdColumn { get; set; }
}