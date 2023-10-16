using MediatR;

namespace ProjectManager.API.Features.Agency.Commands;

public class CreateAgencyCommand : IRequest<Models.Agency>
{
    public string Name { get; set; }
    public string? Description { get; set; }
}