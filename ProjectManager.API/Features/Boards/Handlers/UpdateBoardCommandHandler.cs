using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Boards.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Handlers;

public class UpdateBoardCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<UpdateBoardCommand, Board>, IRequest<Board>
{
    public UpdateBoardCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(context,
        hubContext)
    {
    }

    public async Task<Board> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
    {
        var board = await _context.Boards.FindAsync(request.IdBoard);

        if (board is null)
            throw new Exception("Доска не найдена");

        if (!string.IsNullOrWhiteSpace(request.Name))
            board.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("ReceiveBoardUpdate", board.IdProject);

        return board;
    }
}