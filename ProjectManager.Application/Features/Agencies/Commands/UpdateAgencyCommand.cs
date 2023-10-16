using MediatR;
using ProjectManager.Core.Models;

namespace ProjectManager.Application.Features.Agencies.Commands;

public class UpdateAgencyCommand : IRequest<Agency>
{
    public int IdAgency { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}