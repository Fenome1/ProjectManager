using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Queries;

public class GetAgencyQuery : IRequest<Agency>
{
    public int IdAgency { get; set; }
}