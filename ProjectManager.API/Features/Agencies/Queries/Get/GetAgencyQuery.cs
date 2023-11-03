using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Queries.Get;

public class GetAgencyQuery : BaseQuery<Agency>
{
    public GetAgencyQuery(int idAgency, bool isDeleted)
    {
        IdAgency = idAgency;
        IncludeDeleted = isDeleted;
    }

    public int IdAgency { get; set; }
}