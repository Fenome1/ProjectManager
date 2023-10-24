using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.URL;

namespace ProjectManager.Desktop.Services;

public static class BoardService
{
    public static async Task<List<Board>> GetBoardsByProjectIdAsync(int idProject)
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseApiUrl}/Board/project/{idProject}");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Board>>(data);
    }
}