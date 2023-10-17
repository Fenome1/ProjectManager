using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Agencies.Commands;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Handlers;

public class UpdateAgencyCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>, IRequestHandler<UpdateAgencyCommand, Agency>
{
    public UpdateAgencyCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(context, hubContext)
    {
    }

    public async Task<Agency> Handle(UpdateAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = await _context.Agencies.FindAsync(request.IdAgency);

        if (agency is null)
            throw new Exception("Агенство не найдено");

        if (!string.IsNullOrWhiteSpace(request.Name))
            agency.Name = request.Name;

        if (request.Description is not null || request.Description?.Trim() == "")
            agency.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("ReceiveAgencyUpdate", agency.IdAgency);
        return agency;
    }
    
}