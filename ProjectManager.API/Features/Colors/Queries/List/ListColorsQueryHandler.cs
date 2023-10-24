using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Colors.Queries.List;

public class ListColorQueryHandler : IRequestHandler<ListColorQuery, List<Color>>
{
    private readonly ProjectManagerDbContext _context;

    public ListColorQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Color>> Handle(ListColorQuery request, CancellationToken cancellationToken)
    {
        var colors = await _context.Colors.ToListAsync();
        if (!colors.Any())
            throw new Exception("÷вета не найдены");
        return colors;
    }
}