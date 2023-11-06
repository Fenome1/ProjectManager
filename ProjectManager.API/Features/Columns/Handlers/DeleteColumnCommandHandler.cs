using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Columns.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Handlers;

public class DeleteColumnCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<DeleteColumnCommand, Column>
{
    public DeleteColumnCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(
        context, hubContext)
    {
    }

    public async Task<Column> Handle(DeleteColumnCommand request, CancellationToken cancellationToken)
    {
        var column = await _context.Columns.FindAsync(request.IdColumn);

        if (column is null)
            throw new Exception("Колонка не найдена");

        if (column.IsDeleted)
            throw new Exception("Колонка уже удалена");

        column.IsDeleted = true;

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveColumnDelete", column.IdColumn);

        return column;
    }
}