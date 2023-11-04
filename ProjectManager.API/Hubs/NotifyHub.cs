using Microsoft.AspNetCore.SignalR;

namespace ProjectManager.API.Hubs;

public class NotifyHub : Hub
{
    //Agency
    public async Task SendAgencyCreateNotification(int idAgency)
    {
        await Clients.All.SendAsync("ReceiveAgencyCreate", idAgency);
    }

    public async Task SendAgencyUpdateNotification(int idAgency)
    {
        await Clients.All.SendAsync("ReceiveAgencyUpdate", idAgency);
    }

    public async Task SendAgencyDeleteNotification(int idAgency)
    {
        await Clients.All.SendAsync("ReceiveAgencyDelete", idAgency);
    }

    //Project
    public async Task SendProjectCreateNotification(int idProject)
    {
        await Clients.All.SendAsync("ReceiveProjectCreate", idProject);
    }

    public async Task SendProjectUpdateNotification(int idProject)
    {
        await Clients.All.SendAsync("ReceiveProjectUpdate", idProject);
    }

    public async Task SendProjectDeleteNotification(int idProject)
    {
        await Clients.All.SendAsync("ReceiveProjectDelete", idProject);
    }

    //Board
    public async Task SendBoardCreateNotification(int idBoard)
    {
        await Clients.All.SendAsync("ReceiveBoardCreate", idBoard);
    }

    public async Task SendBoardUpdateNotification(int idBoard)
    {
        await Clients.All.SendAsync("ReceiveBoardUpdate", idBoard);
    }

    public async Task SendBoardDeleteNotification(int idBoard)
    {
        await Clients.All.SendAsync("ReceiveBoardDelete", idBoard);
    }

    //Column
    public async Task SendColumnCreateNotification(int idColumn)
    {
        await Clients.All.SendAsync("ReceiveColumnCreate", idColumn);
    }

    public async Task SendColumnUpdateNotification(int idColumn)
    {
        await Clients.All.SendAsync("ReceiveColumnUpdate", idColumn);
    }

    public async Task SendColumnDeleteNotification(int idColumn)
    {
        await Clients.All.SendAsync("ReceiveColumnDelete", idColumn);
    }

    //Objective
    public async Task SendObjectiveCreateNotification(int idObjective)
    {
        await Clients.All.SendAsync("ReceiveObjectiveCreate", idObjective);
    }

    public async Task SendObjectiveUpdateNotification(int idObjective)
    {
        await Clients.All.SendAsync("ReceiveObjectiveUpdate", idObjective);
    }

    public async Task SendObjectiveDeleteNotification(int idObjective)
    {
        await Clients.All.SendAsync("ReceiveObjectiveUpdate", idObjective);
    }
}