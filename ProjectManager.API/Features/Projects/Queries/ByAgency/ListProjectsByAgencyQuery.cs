using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Queries.ByAgency;

public class ListProjectsByAgencyQuery : BaseQuery<List<Project>>
{
    public ListProjectsByAgencyQuery(int idAgency, bool isDeleted)
    {
        IdAgency = idAgency;
        IncludeDeleted = isDeleted;
    }

    public int IdAgency { get; set; }
}