using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Queries;

public class GetProjectQuery : IRequest<Project>
{
    public int IdProject { get; set; }
}