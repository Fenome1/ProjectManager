using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Queries;

public class ListProjectsQuery: IRequest<List<Project>> { }