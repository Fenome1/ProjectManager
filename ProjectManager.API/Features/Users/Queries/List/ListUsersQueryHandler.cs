using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Queries.List;

public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, List<User>>
{
    private readonly ProjectManagerDbContext _context;

    public ListUsersQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users
            .Include(u => u.IdObjectives
                .Where(o => o.IsDeleted == request.IncludeDeleted))
            .ThenInclude(o => o.IdPriorityNavigation)
            .Where(u => u.IsDeleted == request.IncludeDeleted)
            .ToListAsync();

        if (!users.Any())
            throw new Exception("Пользоватли не найдены");

        return users;
    }
}