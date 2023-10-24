using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Queries.List.ByBoard;

public class ListColumnsByBoardsQueryHandler : IRequestHandler<ListColumnsByBoardQuery, List<Column>>
{
    private readonly ProjectManagerDbContext _context;

    public ListColumnsByBoardsQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Column>> Handle(ListColumnsByBoardQuery request, CancellationToken cancellationToken)
    {
        if (await _context.Boards.FindAsync(request.IdBoard) is null)
            throw new Exception("Доска не найдена");

        var columns = await _context.Columns
            .Where(c => c.IdBoard == request.IdBoard)
            .ToListAsync(cancellationToken);

        if (!columns.Any())
            throw new Exception("Колонок по заданной доске не найдено");

        return columns;
    }
}