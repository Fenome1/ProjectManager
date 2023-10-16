using MediatR;

namespace ProjectManager.Application.Features.Agency.Commands;

public class DeleteAgencyCommand : IRequest<Core.Models.Agency>
{
    public int IdAgency { get; set; }
}