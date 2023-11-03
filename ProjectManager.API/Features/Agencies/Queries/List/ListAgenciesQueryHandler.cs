using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Queries.List;

public class ListAgenciesQueryHandler : IRequestHandler<ListAgenciesQuery, List<Agency>>
{
    private readonly ProjectManagerDbContext _context;

    public ListAgenciesQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Agency>> Handle(ListAgenciesQuery request, CancellationToken cancellationToken)
    {
        var agencies = await _context.Agencies
            .Include(a => a.Projects
                .Where(p => p.IsDeleted == request.IncludeDeleted))
            .Where(a => a.IsDeleted == request.IncludeDeleted)
            .ToListAsync(cancellationToken);

        return agencies;
    }
}