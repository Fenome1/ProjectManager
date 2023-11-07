using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Colors.List;

public class ListColorsQuery : IRequest<List<Color>>
{
}