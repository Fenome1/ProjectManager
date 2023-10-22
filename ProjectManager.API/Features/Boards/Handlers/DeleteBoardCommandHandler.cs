using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Boards.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Boards.Handlers;

public class DeleteBoardCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<DeleteBoardCommand, Board>
{
    public DeleteBoardCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(context,
        hubContext)
    {
    }

    public async Task<Board> Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
    {
        var board = await _context.Boards.FindAsync(request.IdBoard);

        if (board is null)
            throw new Exception("Доска не найдена");

        _context.Boards.Remove(board);

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveBoardUpdate", board.IdProject);

        return board;
    }
}