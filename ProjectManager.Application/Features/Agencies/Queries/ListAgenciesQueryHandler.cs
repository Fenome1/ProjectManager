using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Persistence.Context;

namespace ProjectManager.Application.Features.Agency.Queries
{
    public class ListAgenciesQueryHandler : IRequestHandler<ListAgenciesQuery, List<Core.Models.Agency>>
    {
        private readonly ProjectManagerDbContext _context;

        public ListAgenciesQueryHandler(ProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Core.Models.Agency>> Handle(ListAgenciesQuery request, CancellationToken cancellationToken)
        {
            var agencies = await _context.Agencies
                .ToListAsync(cancellationToken);

            return agencies;
        }
    }
}