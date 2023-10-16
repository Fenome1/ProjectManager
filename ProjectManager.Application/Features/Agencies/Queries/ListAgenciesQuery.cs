using MediatR;
using ProjectManager.Core.Models;

namespace ProjectManager.Application.Features.Agencies.Queries;

public class ListAgenciesQuery : IRequest<List<Agency>>
{
}