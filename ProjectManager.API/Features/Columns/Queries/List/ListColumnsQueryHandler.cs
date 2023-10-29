using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Queries.List;

public class ListColumnsQueryHandler : IRequestHandler<ListColumnsQuery, List<Column>>
{
    private readonly ProjectManagerDbContext _context;

    public ListColumnsQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Column>> Handle(ListColumnsQuery request, CancellationToken cancellationToken)
    {
        var columns = await _context.Columns
            .Include(c => c.IdColorNavigation)
            .ToListAsync(cancellationToken);

        if (!columns.Any())
            throw new Exception("Колонки не найдены");

        return columns;
    }
}