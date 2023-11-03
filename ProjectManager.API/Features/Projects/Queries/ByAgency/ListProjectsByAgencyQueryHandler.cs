using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Queries.ByAgency;

public class ListProjectsByAgencyQueryHandler : IRequestHandler<ListProjectsByAgencyQuery, List<Project>>
{
    private readonly ProjectManagerDbContext _context;

    public ListProjectsByAgencyQueryHandler(ProjectManagerDbContext context, IMapper mapper)
    {
        _context = context;
    }

    public async Task<List<Project>> Handle(ListProjectsByAgencyQuery request, CancellationToken cancellationToken)
    {
        if (await _context.Agencies.FindAsync(request.IdAgency) is null)
            throw new Exception("�������� �� �������");

        var projects = await _context.Projects
            .Include(p => p.Boards
                .Where(b => b.IsDeleted == request.IncludeDeleted))
            .ThenInclude(b => b.Columns.Where(c => c.IsDeleted == request.IncludeDeleted))
            .ThenInclude(c => c.IdColorNavigation)
            .Where(p => p.IdAgency == request.IdAgency)
            .Where(p => p.IsDeleted == request.IncludeDeleted)
            .ToListAsync(cancellationToken);

        if (!projects.Any())
            throw new Exception("�������� �� ��������� �������� �� �������");

        return projects;
    }
}