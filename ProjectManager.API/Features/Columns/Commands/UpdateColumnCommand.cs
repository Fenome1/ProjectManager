using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Commands;

public class UpdateColumnCommand : IRequest<Column>
{
    public int IdColumn { get; set; }
    public string? Name { get; set; }
    public int? IdBoard { get; set; }
    public int? IdColor { get; set; }
}