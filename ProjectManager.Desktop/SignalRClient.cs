using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using static ProjectManager.Desktop.Common.Data.URL;
using static ProjectManager.Desktop.ViewModels.Manager.ManagerViewModel;

namespace ProjectManager.Desktop;

public class SignalRClient
{
    private readonly HubConnection _hubConnection;

    public SignalRClient()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(BaseHubUrl)
            .WithAutomaticReconnect()
            .Build();

        _hubConnection.On<int>("ReceiveAgencyUpdate", async _ => { await Instance.LoadAgenciesAsync(); });
        _hubConnection.On<int>("ReceiveProjectUpdate", Instance.LoadProjectsAsync);
        _hubConnection.On<int>("ReceiveBoardUpdate", Instance.LoadBoardsAsync);
        _hubConnection.On<int>("ReceiveColumnUpdate", Instance.LoadColumnsAsync);
        _hubConnection.On<int>("ReceiveObjectiveUpdate", Instance.LoadObjectivesAsync);
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