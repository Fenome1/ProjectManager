using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Projects.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

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

        _context.Projects.Add(project);

        await _context.SaveChangesAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("ReceiveProjectUpdate", project.IdAgency);

        return project;
    }
}