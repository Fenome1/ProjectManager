using MediatR;

namespace ProjectManager.Application.Features.Agency.Commands;

public class CreateAgencyCommand : IRequest<Core.Models.Agency>
{
    public string Name { get; set; }
    public string? Description { get; set; }
}