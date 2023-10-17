using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Queries;

public class ListProjectsQueryHandler : IRequestHandler<ListProjectsQuery, List<Project>>
{
    private readonly ProjectManagerDbContext _context;

    public ListProjectsQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }
    public async Task<List<Project>> Handle(ListProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _context.Projects.ToListAsync();

        if (!projects.Any())
            throw new Exception("Проекты не найдены");

        return projects;
    }
}