using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Commands.Objectives.Add;

public class AddObjectiveToUserCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<AddObjectiveToUserCommand, User>
{
    public AddObjectiveToUserCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext) : base(
        context, hubContext)
    {
    }

    public async Task<User> Handle(AddObjectiveToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.IdUser);

        if (user is null)
            throw new Exception("Пользователь не найден");

        var objective = await _context.Objectives
            .Include(o => o.IdUsers)
            .FirstOrDefaultAsync(o => o.IdObjective == request.IdObjective);

        if (objective is null)
            throw new Exception("Задача не найдена");

        if (objective.IdUsers.Any(u => u.IdUser == user.IdUser))
            throw new Exception("Пользователь уже подписан на задачу");

        user.IdObjectives.Add(objective);
        await _context.SaveChangesAsync();

        await _hubContext.Clients.Group(user.IdUser.ToString())
            .SendAsync("ReceiveAddObjective", objective.IdObjective);

        return user;
    }
}