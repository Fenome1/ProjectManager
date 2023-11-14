using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Agencies.Commands;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Handlers;

public class DeleteAgencyCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<DeleteAgencyCommand, Agency>
{
    public DeleteAgencyCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(
        context, hubContext)
    {
    }

    public async Task<Agency> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = await _context.Agencies
            .Include(a => a.Projects)
            .ThenInclude(p => p.Boards)
            .ThenInclude(b => b.Columns)
            .ThenInclude(c => c.Objectives)
            .FirstOrDefaultAsync(a => a.IdAgency == request.IdAgency);

        if (agency == null)
            throw new Exception("Агенство не найдено");

        HierarchicalDeletion(agency);

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveAgencyDelete", agency.IdAgency);

        return agency;
    }

    private static void HierarchicalDeletion(Agency agency)
    {
        agency.IsDeleted = true;

        foreach (var project in agency.Projects)
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
}