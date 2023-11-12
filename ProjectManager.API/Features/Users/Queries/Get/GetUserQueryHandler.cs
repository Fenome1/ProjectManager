using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Queries.Get;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
{
    private ProjectManagerDbContext _context;

    public GetUserQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Where(u => u.IsDeleted == request.IncludeDeleted)
            .FirstOrDefaultAsync(u => u.IdUser == request.IdUser);

        if (user is null)
            throw new Exception("Пользоватль не найден");

        return user;
    }
}