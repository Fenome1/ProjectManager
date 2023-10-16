using MediatR;

namespace ProjectManager.API.Features.Agency.Queries
{
    public class ListAgenciesQuery : IRequest<List<Models.Agency>>{};
}