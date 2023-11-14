using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Commands;

public class AuthUserCommand : IRequest<User>
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}