using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Agencies.Commands;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Handlers;

public class CreateAgencyCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<CreateAgencyCommand, Agency>
{
    private readonly IMapper _mapper;

    public CreateAgencyCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext,
        IMapper mapper) : base(context, hubContext)
    {
        _mapper = mapper;
    }

    public async Task<Agency> Handle(CreateAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = _mapper.Map<Agency>(request);

        _context.Agencies.Add(agency);

        await _context.SaveChangesAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("ReceiveAgencyUpdate", agency.IdAgency);

        return agency;
    }
}