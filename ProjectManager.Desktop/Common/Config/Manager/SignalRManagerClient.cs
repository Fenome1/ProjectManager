﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using static ProjectManager.Desktop.Common.Data.Url;
using static ProjectManager.Desktop.ViewModels.Manager.ManagerViewModel;

namespace ProjectManager.Desktop.Common.Config.Manager;

public class SignalRManagerClient
{
    private readonly HubConnection _hubConnection;

    public SignalRManagerClient()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(BaseHubUrl)
            .WithAutomaticReconnect()
            .Build();

        //Agency
        _hubConnection.On<int>("ReceiveAgencyCreate", ManagerVm.CreateAgencyAsync);
        _hubConnection.On<int>("ReceiveAgencyUpdate", ManagerVm.UpdateAgencyAsync);
        _hubConnection.On<int>("ReceiveAgencyDelete", ManagerVm.DeleteAgencyAsync);
        //Project
        _hubConnection.On<int>("ReceiveProjectCreate", ManagerVm.CreateProjectAsync);
        _hubConnection.On<int>("ReceiveProjectUpdate", ManagerVm.UpdateProjectAsync);
        _hubConnection.On<int>("ReceiveProjectDelete", ManagerVm.DeleteProjectAsync);
        //Board
        _hubConnection.On<int>("ReceiveBoardCreate", ManagerVm.CreateBoardAsync);
        _hubConnection.On<int>("ReceiveBoardUpdate", ManagerVm.UpdateBoardAsync);
        _hubConnection.On<int>("ReceiveBoardDelete", ManagerVm.DeleteBoardAsync);
        //Column
        _hubConnection.On<int>("ReceiveColumnCreate", ManagerVm.CreateColumnAsync);
        _hubConnection.On<int>("ReceiveColumnUpdate", ManagerVm.UpdateColumnAsync);
        _hubConnection.On<int>("ReceiveColumnDelete", ManagerVm.DeleteColumnAsync);
        //Objective
        _hubConnection.On<int>("ReceiveObjectiveCreate", ManagerVm.CreateObjectiveAsync);
        _hubConnection.On<int>("ReceiveObjectiveUpdate", ManagerVm.UpdateObjectiveAsync);
        _hubConnection.On<int>("ReceiveObjectiveDelete", ManagerVm.DeleteObjectiveAsync);

        //User
        _hubConnection.On<int>("ReceiveUserUpdate", ManagerVm.UpdateUserAsync);
    }

    public async Task StartConnection()
    {
        await _hubConnection.StartAsync();
        await _hubConnection.InvokeAsync("UserConnected", ManagerVm.User.IdUser);
    }

    public async Task StopConnection()
    {
        await _hubConnection.InvokeAsync("UserDisconnected", ManagerVm.User.IdUser);
        await _hubConnection.StopAsync();
    }
}