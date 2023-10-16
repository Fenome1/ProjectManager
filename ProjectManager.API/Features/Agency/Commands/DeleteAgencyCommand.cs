using MediatR;
namespace ProjectManager.API.Features.Agency.Commands;

public class DeleteAgencyCommand : IRequest<Models.Agency>
{
    public int IdAgency { get; set; }
}