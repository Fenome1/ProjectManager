using MediatR;

namespace ProjectManager.API.Features.Agency.Commands;

public class UpdateAgencyCommand : IRequest<Models.Agency>
{
    public int IdAgency { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}