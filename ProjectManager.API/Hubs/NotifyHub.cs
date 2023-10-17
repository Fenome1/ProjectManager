using Microsoft.AspNetCore.SignalR;

namespace ProjectManager.API.Hubs;

public class NotifyHub : Hub
{
    public async Task SendAgencyUpdateNotification(int agencyId)
    {
        await Clients.All.SendAsync("ReceiveAgencyUpdate", agencyId);
    }
}