using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Queries;

public class ListAgenciesQuery : IRequest<List<Agency>> { }