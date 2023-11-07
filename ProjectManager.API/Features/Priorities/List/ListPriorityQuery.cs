using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Priorities.List;

public class ListPriorityQuery : IRequest<List<Priority>>
{
}