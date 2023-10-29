using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Queries.List.ByColumn;

public class ListObjectivesByColumnQueryHandler : IRequestHandler<ListObjectivesByColumnQuery, List<Objective>>
{
    private readonly ProjectManagerDbContext _context;

    public ListObjectivesByColumnQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Objective>> Handle(ListObjectivesByColumnQuery request, CancellationToken cancellationToken)
    {
        var objectives = await _context.Objectives
            .Include(o => o.IdColumnNavigation)
            .Where(o => o.IdColumn == request.IdColumn)
            .Include(o => o.IdPriorityNavigation)
            .ToListAsync();

        if (!objectives.Any())
            throw new Exception("Заданий не найдено");

        return objectives;
    }
}