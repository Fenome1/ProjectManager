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

        await _context.Projects.AddAsync(project);

        await _context.SaveChangesAsync(cancellationToken);
        await _hubContext.Clients.All.SendAsync("ReceiveProjectUpdate", project.IdAgency);

        await _context.CreateNewBoardForProject(project.IdProject);
        await _hubContext.Clients.All.SendAsync("ReceiveBoardUpdate", project.IdProject);

        return project;
    }
}

public static class CreationService
{
    public static async Task<Board> CreateNewBoardForProject(this ProjectManagerDbContext context, int idProject)
    {
        var newBoard = new Board { Name = "Новая доска", IdProject = idProject };
        await context.Boards.AddAsync(newBoard);
        await context.SaveChangesAsync();
        return newBoard;
    }
}