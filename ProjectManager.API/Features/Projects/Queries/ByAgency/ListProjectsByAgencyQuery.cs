using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Queries.ByAgency;

public class ListProjectsByAgencyQuery : IRequest<List<Project>>
{
    public int IdAgency { get; set; }
}