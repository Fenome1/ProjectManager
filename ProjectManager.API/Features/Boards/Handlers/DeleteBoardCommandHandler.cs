using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
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
        var board = await _context.Boards
            .Include(b => b.Columns)
            .ThenInclude(c => c.Objectives)
            .FirstOrDefaultAsync(b => b.IdBoard == request.IdBoard);

        if (board is null)
            throw new Exception("Доска не найдена");

        if (board.IsDeleted)
            throw new Exception("Доска уже удалена");

        HierarchicalDeletion(board);

        await _context.SaveChangesAsync();

        await _hubContext.Clients.All.SendAsync("ReceiveBoardDelete", board.IdBoard);

        return board;
    }

    private static void HierarchicalDeletion(Board board)
    {
        board.IsDeleted = true;

        foreach (var column in board.Columns)
        {
            column.IsDeleted = true;

            foreach (var objective in column.Objectives) objective.IsDeleted = true;
        }
    }
}