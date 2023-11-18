using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Users.Commands;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Handlers;

public class UpdateUserCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<UpdateUserCommand, User>
{
    public UpdateUserCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(context,
        hubContext)
    {
    }

    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.IdUser);

        if (user is null) throw new Exception("Пользователь не найден");

        if (!string.IsNullOrWhiteSpace(request.FullName))
            user.FullName = request.FullName;

        if (!string.IsNullOrWhiteSpace(request.Login))
            user.Login = request.Login;

        if (!string.IsNullOrEmpty(request.Password))
            user.Password = request.Password;

        if (request.IsImageReset)
            user.Image = null;
        else if (request.Image is not null)
            user.Image = request.Image;

        if (request.Theme is not null)
            user.Theme = (int)request.Theme!;

        await _context.SaveChangesAsync(cancellationToken);

        await _hubContext.Clients.Group(user.IdUser.ToString())
            .SendAsync("ReceiveUserUpdate", user.IdUser);

        return user;
    }
}