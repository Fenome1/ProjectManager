using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Objectives.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Handlers;

public class UpdateObjectiveCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<UpdateObjectiveCommand, Objective>
{
    public UpdateObjectiveCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(
        context, hubContext)
    {
    }

    public async Task<Objective> Handle(UpdateObjectiveCommand request, CancellationToken cancellationToken)
    {
        var objective = await _context.Objectives.FindAsync(request.IdObjective);

        if (objective is null)
            throw new Exception("Задача не найдена");

        if (!string.IsNullOrWhiteSpace(request.Name))
            objective.Name = request.Name;

        if (!string.IsNullOrWhiteSpace(request.Description))
            objective.Description = request.Description;

        if (request.IsDeadlineReset)
            objective.Deadline = null;
        else if (request.Deadline is not null)
            objective.Deadline = request.Deadline;

        if (request.Status is not null)
            objective.Status = (bool)request.Status;

        if (request.IdPriority is not null)
            objective.IdPriority = request.IdPriority;

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveObjectiveUpdate", objective.IdObjective);

        return objective;
    }
}