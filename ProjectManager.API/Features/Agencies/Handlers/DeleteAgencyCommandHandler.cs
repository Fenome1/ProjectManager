using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Agencies.Commands;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Handlers;

public class DeleteAgencyCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>, IRequestHandler<DeleteAgencyCommand, Agency>
{
    public DeleteAgencyCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(context, hubContext)
    {

    }
    public async Task<Agency> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = await _context.Agencies.FindAsync(request.IdAgency);

        if (agency == null)
            return null;

        _context.Agencies.Remove(agency);
        await _context.SaveChangesAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("ReceiveAgencyUpdate", agency.IdAgency);

        return agency;
    }
}