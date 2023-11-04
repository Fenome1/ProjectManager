using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Queries.List;

public class ListObjectivesQuery : BaseQuery<List<Objective>>
{
    public ListObjectivesQuery(bool isDeleted)
    {
        IncludeDeleted = isDeleted;
    }
}