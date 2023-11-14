using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Projects.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Handlers;

public class DeleteProjectCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<DeleteProjectCommand, Project>
{
    public DeleteProjectCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(
        context, hubContext)
    {
    }

    public async Task<Project> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .Include(p => p.Boards)
            .ThenInclude(b => b.Columns)
            .ThenInclude(c => c.Objectives)
            .FirstOrDefaultAsync(p => p.IdProject == request.IdProject);

        if (project is null)
            throw new Exception("Проект не найден");

        HierarchicalDeletion(project);

        await _context.SaveChangesAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("ReceiveProjectDelete", project.IdProject);

        return project;
    }

    private static void HierarchicalDeletion(Project project)
    {
        project.IsDeleted = true;

        foreach (var board in project.Boards)
        {
            board.IsDeleted = true;

            foreach (var column in board.Columns)
            {
                column.IsDeleted = true;

                foreach (var objective in column.Objectives) objective.IsDeleted = true;
            }
        }
    }
}