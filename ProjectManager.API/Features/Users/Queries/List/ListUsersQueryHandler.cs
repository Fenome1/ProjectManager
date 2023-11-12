using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Users.Queries.Get;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Queries.List;

public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, List<User>>
{
    private ProjectManagerDbContext _context;

    public ListUsersQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users
            .Where(u => u.IsDeleted == request.IncludeDeleted)
            .ToListAsync();

        if (!users.Any())
            throw new Exception("Пользоватли не найдены");

        return users;
    }
}