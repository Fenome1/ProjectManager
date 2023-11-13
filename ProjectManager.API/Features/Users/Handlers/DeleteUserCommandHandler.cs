using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Users.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Handlers;

public class DeleteUserCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<DeleteUserCommand, User>
{
    public DeleteUserCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(context,
        hubContext)
    {
    }

    public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.IdUser);

        if (user is null)
            throw new Exception("Пользователь не найден");

        if (user.IsDeleted)
            throw new Exception("Пользователь уже удален");

        user.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("ReceiveUserDelete", user.IdUser);

        return user;
    }
}