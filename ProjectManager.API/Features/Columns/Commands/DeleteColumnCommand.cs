using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Commands;

public class DeleteColumnCommand : IRequest<Column>
{
    public int IdColumn { get; set; }
}