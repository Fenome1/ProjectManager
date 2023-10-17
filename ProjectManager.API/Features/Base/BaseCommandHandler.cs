using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.API.Features.Base;

public abstract class BaseCommandHandler<IDbContext, IHub> where IDbContext : DbContext where IHub : Hub, new()
{
    protected readonly IDbContext _context;
    protected readonly IHubContext<IHub> _hubContext;

    protected BaseCommandHandler(IDbContext context, IHubContext<IHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }
}