using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Users.Commands;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Handlers;

public class AuthUserCommandHandler : IRequestHandler<AuthUserCommand, User>
{
    private readonly ProjectManagerDbContext _context;

    public AuthUserCommandHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(AuthUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.IdObjectives
                .Where(o => o.IsDeleted == false))
            .Where(u => u.IsDeleted == false)
            .FirstOrDefaultAsync(u => u.Login == request.Login &&
                                      u.Password == request.Password);

        if (user is null)
            throw new Exception("Не верный логин или пароль");

        return user;
    }
}