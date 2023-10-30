using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Commands;

public class UpdateProjectCommand : IRequest<Project>
{
    public int IdProject { get; set; }
    public string? Name { get; set; }
}