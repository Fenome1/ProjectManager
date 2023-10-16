using MediatR;
using ProjectManager.Core.Models;

namespace ProjectManager.Application.Features.Agencies.Commands;

public class CreateAgencyCommand : IRequest<Agency>
{
    public string Name { get; set; }
    public string? Description { get; set; }
}