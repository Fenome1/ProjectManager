using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Queries;

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