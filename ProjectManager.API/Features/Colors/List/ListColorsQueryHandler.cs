using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Colors.List;

public class ListColorsQueryHandler : IRequestHandler<ListColorsQuery, List<Color>>
{
    private readonly ProjectManagerDbContext _context;

    public ListColorsQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Color>> Handle(ListColorsQuery request, CancellationToken cancellationToken)
    {
        var colors = await _context.Colors.ToListAsync();

        if (!colors.Any())
            throw new Exception("Цвета не найдены");

        return colors;
    }
}