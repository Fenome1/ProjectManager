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
            .Include(p => p.Boards
                .Where(b => b.IsDeleted == request.IncludeDeleted))
            .Where(p => p.IsDeleted == request.IncludeDeleted)
            .ToListAsync();

        if (!projects.Any())
            throw new Exception("������� �� �������");

        return projects;
    }
}