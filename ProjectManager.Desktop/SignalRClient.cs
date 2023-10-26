using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using static ProjectManager.Desktop.Common.URL;
using static ProjectManager.Desktop.ViewModels.MainWindowViewModel;

namespace ProjectManager.Desktop;

public class SignalRClient
{
    private readonly HubConnection _hubConnection;

    public SignalRClient()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(BaseHubUrl)
            .Build();

        _hubConnection.On<int>("ReceiveAgencyUpdate", async _ => { Instance.LoadAgenciesAsync(); });
        _hubConnection.On<int>("ReceiveProjectUpdate", async idAgency => { Instance.LoadProjectsAsync(idAgency); });
        _hubConnection.On<int>("ReceiveBoardUpdate", async idProject => { Instance.LoadBoardsAsync(idProject); });
        _hubConnection.On<int>("ReceiveColumnUpdate", async idBoard => { Instance.LoadColumnsAsync(idBoard); });
        _hubConnection.On<int>("ReceiveObjectiveUpdate", async idColumn => { Instance.LoadObjectivesAsync(idColumn); });
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