using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Commands;

public class UpdateUserCommand : IRequest<User>
{
    public int IdUser { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? FullName { get; set; }
    public string? Image { get; set; }
    public int? Theme { get; set; }
}