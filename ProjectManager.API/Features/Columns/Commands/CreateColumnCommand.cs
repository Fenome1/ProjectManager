using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Commands;

public class CreateColumnCommand : IRequest<Column>
{
    public string Name { get; set; } = null!;
    public int IdBoard { get; set; }
}