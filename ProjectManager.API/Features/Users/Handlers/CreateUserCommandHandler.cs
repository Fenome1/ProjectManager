using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using ProjectManager.API.Context;
using ProjectManager.API.Features.Base;
using ProjectManager.API.Features.Users.Commands;
using ProjectManager.API.Features.Users.Queries.Check;
using ProjectManager.API.Hubs;
using ProjectManager.API.Models;
using ProjectManager.API.Services;

namespace ProjectManager.API.Features.Users.Handlers;

public class CreateUserCommandHandler : BaseCommandHandler<ProjectManagerDbContext, NotifyHub>,
    IRequestHandler<CreateUserCommand, User>
{
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(ProjectManagerDbContext context, IHubContext<NotifyHub> hubContext, IMapper mapper)
        : base(context, hubContext)
    {
        _mapper = mapper;
    }

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var user = _mapper.Map<User>(request);

        user.HashedPassword = HashService.HashPassword(request.Password);

        _context.Users.Add(user);

        await _context.SaveChangesAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("ReceiveUserCreate", user.IdUser);

        return user;
    }
}