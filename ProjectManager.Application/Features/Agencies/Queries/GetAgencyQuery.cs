using MediatR;

namespace ProjectManager.Application.Features.Agency.Queries
{
    public class GetAgencyQuery : IRequest<Core.Models.Agency>
    {
        public int IdAgency { get; set; }
    }
}