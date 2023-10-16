using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Models;
using ProjectManager.Persistence.Context;

namespace ProjectManager.Application.Features.Agencies.Queries;

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
            .ToListAsync(cancellationToken);

        return agencies;
    }
}