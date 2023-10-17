using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Agencies.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Handlers;

public class DeleteAgencyCommandHandler : IRequestHandler<DeleteAgencyCommand, Agency>
{
    private readonly ProjectManagerDbContext _context;
    private readonly IHubContext<NotifyHub> _hubContext;

    public DeleteAgencyCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext1)
    {
        _context = context;
        _hubContext = hubContext1;
    }

    public async Task<Agency> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = await _context.Agencies.FindAsync(request.IdAgency);

        if (agency == null)
            return null;

        _context.Agencies.Remove(agency);
        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveAgencyUpdate", agency.IdAgency);

        return agency;
    }
}