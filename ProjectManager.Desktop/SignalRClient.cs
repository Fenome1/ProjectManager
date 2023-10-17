using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using ProjectManager.API.Models;

namespace ProjectManager.Desktop;

public class SignalRClient
{
    private readonly HubConnection _hubConnection;
    private readonly MainWindow _mainWindow;

    public SignalRClient(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
        _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7172/notifyHub")
            .Build();

        _hubConnection.On<int>("ReceiveAgencyUpdate", async _ =>
        {
            var updatedAgencies = await UpdateAgencies();
            _mainWindow.UpdateAgencies(updatedAgencies);
        });
    }

    public async Task Start()
    {
        await _hubConnection.StartAsync();
    }

    public async Task Stop()
    {
        await _hubConnection.StopAsync();
    }

    public static async Task<List<Agency>?> UpdateAgencies()
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync("https://localhost:7172/api/Agency");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Agency>>(data);
    }
}