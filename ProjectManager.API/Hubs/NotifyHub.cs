using Microsoft.AspNetCore.SignalR;

namespace ProjectManager.API.Hubs;

public class NotifyHub : Hub
{
    public async Task SendAgencyUpdateNotification(int agencyId)
    {
        await Clients.All.SendAsync("ReceiveAgencyUpdate", agencyId);
    }

    public async Task SendProjectUpdateNotification(int idAgency)
    {
        await Clients.All.SendAsync("ReceiveProjectUpdate", idAgency);
    }

    public async Task SendBoardUpdateNotification(int idProject)
    {
        await Clients.All.SendAsync("ReceiveBoardUpdate", idProject);
    }
}