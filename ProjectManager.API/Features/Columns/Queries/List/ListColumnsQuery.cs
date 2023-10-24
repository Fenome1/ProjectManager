using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Queries.List;

public class ListColumnsQuery : IRequest<List<Column>>
{
}