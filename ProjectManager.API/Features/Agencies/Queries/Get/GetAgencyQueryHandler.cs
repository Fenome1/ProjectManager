using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Queries.Get;

public class GetAgencyQueryHandler : IRequestHandler<GetAgencyQuery, Agency>
{
    private readonly ProjectManagerDbContext _context;

    public GetAgencyQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Agency> Handle(GetAgencyQuery request, CancellationToken cancellationToken)
    {
        var agency = await _context.Agencies
            .Include(a => a.Projects)
            .ThenInclude(p => p.Boards)
            .ThenInclude(b => b.Columns)
            .ThenInclude(b => b.IdColorNavigation)
            .Include(a => a.Projects
                .Where(p => p.IsDeleted == request.IncludeDeleted))
            .ThenInclude(p => p.Boards
                .Where(b => b.IsDeleted == request.IncludeDeleted))
            .ThenInclude(b => b.Columns
                .Where(c => c.IsDeleted == request.IncludeDeleted))
            .ThenInclude(c => c.Objectives
                .Where(o => o.IsDeleted == request.IncludeDeleted))
            .ThenInclude(o => o.IdPriorityNavigation)
            .Where(a => a.IsDeleted == request.IncludeDeleted)
            .FirstOrDefaultAsync(a => a.IdAgency == request.IdAgency);

        if (agency is null)
            throw new Exception("Агенство не найдено");

        return agency;
    }
}