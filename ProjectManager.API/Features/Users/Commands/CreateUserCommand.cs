using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Commands;

public class CreateUserCommand : IRequest<User>
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int Role { get; set; }
}