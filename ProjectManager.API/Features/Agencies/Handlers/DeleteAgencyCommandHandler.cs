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
            .FirstOrDefaultAsync(a => a.IdAgency == request.IdAgency);

        if (agency == null)
            throw new Exception("Агенство не найдено");

        if (agency.IsDeleted)
            throw new Exception("Агенство уже удалено");

        agency.IsDeleted = true;

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveAgencyDelete", agency.IdAgency);

        return agency;
    }
}