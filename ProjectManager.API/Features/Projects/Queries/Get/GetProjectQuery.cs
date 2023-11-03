using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Queries.Get;

public class GetProjectQuery : BaseQuery<Project>
{
    public GetProjectQuery(int idProject, bool isDeleted)
    {
        IdProject = idProject;
        IncludeDeleted = isDeleted;
    }

    public int IdProject { get; set; }
}