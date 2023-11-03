using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Projects.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;
using ProjectManager.API.Services;

namespace ProjectManager.API.Features.Projects.Handlers;

public class CreateProjectCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<CreateProjectCommand, Project>
{
    private readonly IMapper _mapper;

    public CreateProjectCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext,
        IMapper mapper) : base(context, hubContext)
    {
        _mapper = mapper;
    }

    public async Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        if (await _context.Agencies.FindAsync(request.IdAgency) is null) throw new Exception("Агенство не найдено");

        var project = _mapper.Map<Project>(request);

        await _context.Projects.AddAsync(project);

        await _context.SaveChangesAsync(cancellationToken);

        var newBoard = await _context.CreateNewBoardForProjectAsync(project.IdProject);

        await _context.CreateNewColumnForBoardAsync(newBoard.IdBoard);

        await _hubContext.Clients.All.SendAsync("ReceiveProjectCreate", project.IdProject);

        return project;
    }
}