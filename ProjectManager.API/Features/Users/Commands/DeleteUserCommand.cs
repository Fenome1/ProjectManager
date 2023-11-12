using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Commands;

public class DeleteUserCommand : IRequest<User>
{
    public int IdUser { get; set; }
}