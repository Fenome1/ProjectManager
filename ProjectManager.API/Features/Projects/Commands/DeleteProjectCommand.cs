using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Commands
{
    public class DeleteProjectCommand : IRequest<Project>
    {
        public int IdProject { get; set; }
    }
}
