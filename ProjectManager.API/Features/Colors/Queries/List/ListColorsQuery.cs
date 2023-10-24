using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Colors.Queries.List;

public class ListColorQuery : IRequest<List<Color>>
{
}