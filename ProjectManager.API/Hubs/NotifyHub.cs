using Microsoft.AspNetCore.SignalR;

namespace ProjectManager.API.Hubs;

public class NotifyHub : Hub
{
    public async Task UserConnected(int idUser)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, idUser.ToString());
    }

    public async Task UserDisconnected(int idUser)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, idUser.ToString());
    }
}