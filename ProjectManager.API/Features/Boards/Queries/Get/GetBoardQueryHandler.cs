using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Queries.Get;

public class GetBoardQueryHandler : IRequestHandler<GetBoardQuery, Board>
{
    private readonly ProjectManagerDbContext _context;

    public GetBoardQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Board> Handle(GetBoardQuery request, CancellationToken cancellationToken)
    {
        var board = await _context.Boards
            .Include(b => b.Columns
                .Where(c => c.IsDeleted == request.IncludeDeleted))
            .ThenInclude(c => c.IdColorNavigation)
            .Where(b => b.IsDeleted == request.IncludeDeleted)
            .FirstOrDefaultAsync(b => b.IdBoard == request.IdBoard);

        if (board is null)
            throw new Exception("Доска не найден");

        return board;
    }
}