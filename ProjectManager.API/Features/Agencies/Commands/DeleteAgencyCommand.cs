using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Commands;

public class DeleteAgencyCommand : IRequest<Agency>
{
    public int IdAgency { get; set; }
}