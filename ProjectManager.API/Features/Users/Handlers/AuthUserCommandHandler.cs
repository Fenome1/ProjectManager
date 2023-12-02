using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Users.Commands;
using ProjectManager.API.Models;
using ProjectManager.API.Services;

namespace ProjectManager.API.Features.Users.Handlers;

public class AuthUserCommandHandler : IRequestHandler<AuthUserCommand, User>
{
    private readonly ProjectManagerDbContext _context;

    private const string ErrorMessage = "Не верный логин или пароль";

    public AuthUserCommandHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(AuthUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.IdObjectives
                .Where(o => o.IsDeleted == false))
            .ThenInclude(o => o.IdPriorityNavigation)
            .Where(u => u.IsDeleted == false)
            .FirstOrDefaultAsync(u => u.Login == request.Login);

        if (user is null)
            throw new Exception(ErrorMessage);

        var passwordMatch = HashService.VerifyPassword(request.Password,
            user.HashedPassword);

        if (!passwordMatch)
            throw new Exception(ErrorMessage);

        return user;
    }
}