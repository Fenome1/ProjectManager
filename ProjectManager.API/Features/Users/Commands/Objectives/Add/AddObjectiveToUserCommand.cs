using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Commands.Objectives.Add
{
    public class AddObjectiveToUserCommand : IRequest<User>
    {
        public int IdUser { get; set; }
        public int IdObjective { get; set; }
    }
}
