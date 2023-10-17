using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Agencies.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Handlers;

public class CreateAgencyCommandHandler : IRequestHandler<CreateAgencyCommand, Agency>
{
    private readonly ProjectManagerDbContext _context;
    private readonly IHubContext<NotifyHub> _hubContext;

    public CreateAgencyCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }

    public async Task<Agency> Handle(CreateAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = new Agency
        {
            Name = request.Name,
            Description = request.Description
        };

        _context.Agencies.Add(agency);

        await _context.SaveChangesAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("ReceiveAgencyUpdate", agency.IdAgency);

        return agency;
    }
}