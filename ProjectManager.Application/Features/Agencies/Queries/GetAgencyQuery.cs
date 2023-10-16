using MediatR;
using ProjectManager.Core.Models;

namespace ProjectManager.Application.Features.Agencies.Queries;

public class GetAgencyQuery : IRequest<Agency>
{
    public int IdAgency { get; set; }
}