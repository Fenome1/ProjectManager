using MediatR;

namespace ProjectManager.Application.Features.Agency.Queries
{
    public class ListAgenciesQuery : IRequest<List<Core.Models.Agency>> { };
}