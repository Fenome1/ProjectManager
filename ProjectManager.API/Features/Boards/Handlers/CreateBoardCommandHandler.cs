using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Boards.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Handlers;

public class CreateBoardCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<CreateBoardCommand, Board>
{
    private readonly IMapper _mapper;

    public CreateBoardCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext, IMapper mapper)
        : base(context, hubContext)
    {
        _mapper = mapper;
    }

    public async Task<Board> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
    {
        if (await _context.Projects.FindAsync(request.IdProject) is null)
            throw new Exception("Привязываеммый проект не найден");

        var board = _mapper.Map<CreateBoardCommand, Board>(request);

        await _context.Boards.AddAsync(board);

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveBoardUpdate", board.IdProject);

        return board;
    }
}