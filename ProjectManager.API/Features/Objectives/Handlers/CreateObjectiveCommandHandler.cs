using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Objectives.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Handlers;

public class CreateObjectiveCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<CreateObjectiveCommand, Objective>
{
    private readonly IMapper _mapper;

    public CreateObjectiveCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext,
        IMapper mapper) : base(context, hubContext)
    {
        _mapper = mapper;
    }

    public async Task<Objective> Handle(CreateObjectiveCommand request, CancellationToken cancellationToken)
    {
        var column = await _context.Columns.FindAsync(request.IdColumn);

        if (column is null)
            throw new Exception("Привязываемая колонка не найдена");

        var objective = _mapper.Map<CreateObjectiveCommand, Objective>(request);

        await _context.Objectives.AddAsync(objective);

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveObjectiveUpdate", objective.IdColumn);

        return objective;
    }
}