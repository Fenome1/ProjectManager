using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Agencies.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Handlers;

public class UpdateAgencyCommandHandler : IRequestHandler<UpdateAgencyCommand, Agency>
{
    private readonly ProjectManagerDbContext _context;
    private readonly IHubContext<NotifyHub> _hubContext;

    public UpdateAgencyCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }

    public async Task<Agency> Handle(UpdateAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = await _context.Agencies.FindAsync(request.IdAgency);

        if (agency is null)
            return null;

        if (!string.IsNullOrWhiteSpace(request.Name))
            agency.Name = request.Name;

        if (request.Description is not null || request.Description?.Trim() == "")
            agency.Description = request.Description;

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveAgencyUpdate", agency.IdAgency);
        return agency;
    }
}