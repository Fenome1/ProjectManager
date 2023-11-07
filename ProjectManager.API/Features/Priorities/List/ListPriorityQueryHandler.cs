using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Priorities.List;

public class ListPriorityQueryHandler : IRequestHandler<ListPriorityQuery, List<Priority>>
{
    private readonly ProjectManagerDbContext _context;

    public ListPriorityQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Priority>> Handle(ListPriorityQuery request, CancellationToken cancellationToken)
    {
        var priorities = await _context.Priorities.ToListAsync();

        if (!priorities.Any())
            throw new Exception("Цвета не найдены");

        return priorities;
    }
}