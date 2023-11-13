using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Queries.List.ByRole;

public class ListUsersByRoleQueryHandler : IRequestHandler<ListUsersByRoleQuery, List<User>>
{
    private readonly ProjectManagerDbContext _context;

    public ListUsersByRoleQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> Handle(ListUsersByRoleQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users
            .Include(u => u.IdObjectives
                .Where(o => o.IsDeleted == request.IncludeDeleted))
            .Where(u => u.IsDeleted == request.IncludeDeleted)
            .Where(u => u.Role == request.Role)
            .ToListAsync();

        if (!users.Any())
            throw new Exception("Пользоватли не найдены");

        return users;
    }
}