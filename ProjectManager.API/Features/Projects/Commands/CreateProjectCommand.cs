using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Commands;

public class CreateProjectCommand : IRequest<Project>
{
    public string Name { get; set; } = null!;
    public int IdAgency { get; set; }
}