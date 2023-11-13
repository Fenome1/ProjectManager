using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using static ProjectManager.Desktop.Common.Data.URL;
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

        //Objective
        _hubConnection.On<int>("ReceiveObjectiveUpdate", ExecutorVm.UpdateObjectiveAsync);
        _hubConnection.On<int>("ReceiveObjectiveDelete", ExecutorVm.DeleteObjectiveAsync);

        _hubConnection.On<int>("ReceiveAddObjective", ExecutorVm.ObjectiveAddAssignAsync);
        _hubConnection.On<int>("ReceiveDeleteObjective", ExecutorVm.ObjectiveDeleteAssignAsync);
    }

    public async Task Start()
    {
        await _hubConnection.StartAsync();
    }

    public async Task Stop()
    {
        await _hubConnection.StopAsync();
    }
}