using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Commands;

public class CreateAgencyCommand : IRequest<Agency>
{
    public string Name { get; set; }
    public string? Description { get; set; }
}