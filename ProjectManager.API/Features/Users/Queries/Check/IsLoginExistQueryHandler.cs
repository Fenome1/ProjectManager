using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;

namespace ProjectManager.API.Features.Users.Queries.Check;

public class IsLoginExistQueryHandler : IRequestHandler<IsLoginExistQuery, bool>
{
    private readonly ProjectManagerDbContext _context;

    public IsLoginExistQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(IsLoginExistQuery request, CancellationToken cancellationToken)
    {
        var isLoginExist = await _context.Users
            .Where(u => u.IsDeleted == request.IncludeDeleted)
            .AnyAsync(u => u.Login == request.Login);

        return isLoginExist;
    }
}