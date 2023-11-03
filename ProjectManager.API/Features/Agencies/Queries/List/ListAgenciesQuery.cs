using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Queries.List;

public class ListAgenciesQuery : BaseQuery<List<Agency>>
{
    public ListAgenciesQuery(bool isDeleted)
    {
        IncludeDeleted = isDeleted;
    }
}