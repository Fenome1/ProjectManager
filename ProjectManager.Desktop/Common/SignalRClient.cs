using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using static ProjectManager.Desktop.Common.Data.URL;
using static ProjectManager.Desktop.ViewModels.Manager.ManagerViewModel;

namespace ProjectManager.Desktop.Common;

public class SignalRClient
{
    private readonly HubConnection _hubConnection;

    public SignalRClient()
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