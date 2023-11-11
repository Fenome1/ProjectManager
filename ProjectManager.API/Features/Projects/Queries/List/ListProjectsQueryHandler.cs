using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Queries.List;

public class ListProjectsQueryHandler : IRequestHandler<ListProjectsQuery, List<Project>>
{
    private readonly ProjectManagerDbContext _context;

    public ListProjectsQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> Handle(ListProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _context.Projects
            .Include(p => p.Boards)
            .ThenInclude(b => b.Columns)
            .ThenInclude(b => b.IdColorNavigation)
            .Include(p => p.Boards
                .Where(b => b.IsDeleted == request.IncludeDeleted))
            .ThenInclude(b => b.Columns
                .Where(c => c.IsDeleted == request.IncludeDeleted))
            .ThenInclude(c => c.Objectives
                .Where(o => o.IsDeleted == request.IncludeDeleted))
            .ThenInclude(o => o.IdPriorityNavigation)
            .Where(p => p.IsDeleted == request.IncludeDeleted)
            .ToListAsync();

        if (!projects.Any())
            throw new Exception("Проекты не найдены");

        return projects;
    }
}