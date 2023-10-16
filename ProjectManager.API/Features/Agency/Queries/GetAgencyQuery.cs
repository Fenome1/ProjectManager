using MediatR;

namespace ProjectManager.API.Features.Agency.Queries;

public class GetAgencyQuery : IRequest<Models.Agency>
{
    public int IdAgency { get; set; }
}