using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Projects.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Handlers
{
    public class DeleteProjectCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>, IRequestHandler<DeleteProjectCommand, Project>
    {
        public DeleteProjectCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(context, hubContext)
        {
        }

        public async Task<Project> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FindAsync(request.IdProject);

            if (project == null)
                throw new Exception("Проект не найден");

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync(cancellationToken);

            await _hubContext.Clients.All.SendAsync("ReceiveProjectUpdate", project.IdAgency);

            return project;
        }
    }
}
