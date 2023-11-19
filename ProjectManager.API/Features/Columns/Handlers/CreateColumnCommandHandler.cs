using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Columns.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Handlers;

public class CreateColumnCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<CreateColumnCommand, Column>
{
    private readonly IMapper _mapper;

    public CreateColumnCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext,
        IMapper mapper) : base(context, hubContext)
    {
        _mapper = mapper;
    }

    public async Task<Column> Handle(CreateColumnCommand request, CancellationToken cancellationToken)
    {
        if (await _context.Boards.FindAsync(request.IdBoard) is null)
            throw new Exception("Привязываемая доска не найдена");

        var column = _mapper.Map<CreateColumnCommand, Column>(request);

        await _context.Columns.AddAsync(column);

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveColumnCreate", column.IdColumn);

        return column;
    }
}