using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Queries.Get;

public class GetColumnQueryHandler : IRequestHandler<GetColumnQuery, Column>
{
    private readonly ProjectManagerDbContext _context;

    public GetColumnQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Column> Handle(GetColumnQuery request, CancellationToken cancellationToken)
    {
        var column = await _context.Columns
            .Include(c => c.Objectives
                .Where(o => o.IsDeleted == request.IncludeDeleted))
            .ThenInclude(o => o.IdPriorityNavigation)
            .Where(c => c.IsDeleted == request.IncludeDeleted)
            .Include(c => c.IdColorNavigation)
            .FirstOrDefaultAsync(c => c.IdColumn == request.IdColumn);

        if (column == null)
            throw new Exception("Колонка не найдена");

        return column;
    }
}