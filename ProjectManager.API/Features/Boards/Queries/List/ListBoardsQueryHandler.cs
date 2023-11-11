using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Queries.List;

public class ListBoardsQueryHandler : IRequestHandler<ListBoardsQuery, List<Board>>
{
    private readonly ProjectManagerDbContext _context;

    public ListBoardsQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Board>> Handle(ListBoardsQuery request, CancellationToken cancellationToken)
    {
        {
            var boards = await _context.Boards
                .Include(b => b.Columns
                    .Where(c => c.IsDeleted == request.IncludeDeleted))
                .ThenInclude(c => c.IdColorNavigation)
                .ThenInclude(b => b.Columns
                    .Where(c => c.IsDeleted == request.IncludeDeleted))
                .ThenInclude(c => c.Objectives
                    .Where(o => o.IsDeleted == request.IncludeDeleted))
                .ThenInclude(o => o.IdPriorityNavigation)
                .Where(b => b.IsDeleted == request.IncludeDeleted)
                .ToListAsync();

            if (!boards.Any())
                throw new Exception("Проекты не найдены");

            return boards;
        }
    }
}