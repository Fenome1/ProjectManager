using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Queries.List;

public class ListObjectivesQueryHandler : IRequestHandler<ListObjectivesQuery, List<Objective>>
{
    private readonly ProjectManagerDbContext _context;

    public ListObjectivesQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Objective>> Handle(ListObjectivesQuery request, CancellationToken cancellationToken)
    {
        var objectives = await _context.Objectives
            .Where(o => o.IsDeleted == request.IncludeDeleted)
            .Include(o => o.IdPriorityNavigation)
            .ToListAsync();

        if (!objectives.Any())
            throw new Exception("Задачи не найдены");

        return objectives;
    }
}