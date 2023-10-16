using MediatR;

namespace ProjectManager.Application.Features.Agency.Commands;

public class UpdateAgencyCommand : IRequest<Core.Models.Agency>
{
    public int IdAgency { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}