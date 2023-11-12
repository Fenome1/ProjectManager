using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Roles.List;

public class ListRolesQueryHandler : IRequestHandler<ListRolesQuery, List<Role>>
{
    private ProjectManagerDbContext _context;

    public ListRolesQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Role>> Handle(ListRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _context.Roles.ToListAsync();

        if (!roles.Any())
            throw new Exception("Цвета не найдены");

        return roles;
    }
}