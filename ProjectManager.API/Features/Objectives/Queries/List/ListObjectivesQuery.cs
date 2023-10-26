using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Queries.List;

public class ListObjectivesQuery : IRequest<List<Objective>>, IRequest<List<object>>
{
}