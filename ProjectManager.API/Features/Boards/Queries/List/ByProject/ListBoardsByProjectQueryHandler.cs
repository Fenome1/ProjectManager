using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Queries.List.ByProject;

public class ListBoardsByProjectQueryHandler : IRequestHandler<ListBoardsByProjectQuery, List<Board>>
{
    private readonly ProjectManagerDbContext _context;

    public ListBoardsByProjectQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Board>> Handle(ListBoardsByProjectQuery request, CancellationToken cancellationToken)
    {
        if (await _context.Projects.FindAsync(request.IdProject) is null)
            throw new Exception("Проект не найден");

        var boards = await _context.Boards
            .Include(b => b.Columns)
            .ThenInclude(c => c.IdColorNavigation)
            .ThenInclude(b => b.Columns
                .Where(c => c.IsDeleted == request.IncludeDeleted))
            .ThenInclude(c => c.Objectives
                .Where(o => o.IsDeleted == request.IncludeDeleted))
            .ThenInclude(o => o.IdPriorityNavigation)
            .Where(p => p.IsDeleted == request.IncludeDeleted)
            .Where(p => p.IdProject == request.IdProject)
            .ToListAsync(cancellationToken);

        if (!boards.Any())
            throw new Exception("Досок по заданному проекту не найдено");

        return boards;
    }
}