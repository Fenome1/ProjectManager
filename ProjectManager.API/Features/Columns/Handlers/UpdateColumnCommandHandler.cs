using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Columns.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Handlers;

public class UpdateColumnCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<UpdateColumnCommand, Column>
{
    public UpdateColumnCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(
        context, hubContext)
    {
    }

    public async Task<Column> Handle(UpdateColumnCommand request, CancellationToken cancellationToken)
    {
        var column = await _context.Columns.FindAsync(request.IdColumn);

        if (column == null)
            throw new Exception("Колонка не найдена");

        if (!string.IsNullOrWhiteSpace(request.Name))
            column.Name = request.Name;

        if (request.IdColor is not null)
            column.IdColor = (int)request.IdColor;

        await _context.SaveChangesAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("ReceiveBoardUpdate", column.IdColumn);

        return column;
    }
}