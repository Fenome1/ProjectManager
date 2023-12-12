using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using static ProjectManager.Desktop.Common.Data.Url;
using static ProjectManager.Desktop.ViewModels.Executor.ExecutorViewModel;

namespace ProjectManager.Desktop.Common.Config.Executor;

public class SignalRExecutorClient
{
    private readonly HubConnection _hubConnection;

    public SignalRExecutorClient()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(BaseHubUrl)
            .WithAutomaticReconnect()
            .Build();


        //Delete Update
        _hubConnection.On<int>("ReceiveAgencyDelete", _ => { ExecutorVm.GetObjectivesAsync(); });
        _hubConnection.On<int>("ReceiveProjectDelete", _ => { ExecutorVm.GetObjectivesAsync(); });
        _hubConnection.On<int>("ReceiveBoardDelete", _ => { ExecutorVm.GetObjectivesAsync(); });
        _hubConnection.On<int>("ReceiveColumnDelete", _ => { ExecutorVm.GetObjectivesAsync(); });
        _hubConnection.On<int>("ReceiveDeleteObjective", ExecutorVm.ObjectiveDeleteAssignAsync);

        //User - Objective
        _hubConnection.On<int>("ReceiveObjectiveUpdate", ExecutorVm.UpdateObjectiveAsync);
        _hubConnection.On<int>("ReceiveObjectiveDelete", ExecutorVm.DeleteObjectiveAsync);
        _hubConnection.On<int>("ReceiveAddObjective", ExecutorVm.ObjectiveAddAssignAsync);

        //User
        _hubConnection.On<int>("ReceiveUserUpdate", ExecutorVm.UpdateUserAsync);
    }

    public async Task StartConnection()
    {
        await _hubConnection.StartAsync();
        await _hubConnection.InvokeAsync("UserConnected", ExecutorVm.User.IdUser);
    }

    public async Task StopConnection()
    {
        await _hubConnection.InvokeAsync("UserDisconnected", ExecutorVm.User.IdUser);
        await _hubConnection.StopAsync();
    }
}