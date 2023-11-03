using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Queries.List;

public class ListProjectsQuery : BaseQuery<List<Project>>
{
    public ListProjectsQuery(bool isDeleted)
    {
        IncludeDeleted = isDeleted;
    }
}