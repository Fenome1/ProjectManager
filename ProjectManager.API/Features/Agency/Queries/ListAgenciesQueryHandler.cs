using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Data;

namespace ProjectManager.API.Features.Agency.Queries
{
    public class ListAgenciesQueryHandler : IRequestHandler<ListAgenciesQuery, List<Models.Agency>>
    {
        private readonly ProjectManagerDbContext _context;

        public ListAgenciesQueryHandler(ProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Agency>> Handle(ListAgenciesQuery request, CancellationToken cancellationToken)
        {
            var agencies = await _context.Agencies
                .ToListAsync(cancellationToken);

            return agencies;
        }
    }
}