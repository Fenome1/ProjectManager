using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Objectives.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Handlers;

public class DeleteObjectiveCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<DeleteObjectiveCommand, Objective>
{
    public DeleteObjectiveCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(
        context, hubContext)
    {
    }

    public async Task<Objective> Handle(DeleteObjectiveCommand request, CancellationToken cancellationToken)
    {
        var objective = await _context.Objectives.FindAsync(request.IdObjective);

        if (objective is null)
            throw new Exception("Задача не найдена");

        if (objective.IsDeleted)
            throw new Exception("Задача уже удалена");

        objective.IsDeleted = true;

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveObjectiveDelete", objective.IdObjective);

        return objective;
    }
}