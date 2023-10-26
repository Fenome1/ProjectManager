using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.URL;

namespace ProjectManager.Desktop.Services;

public static class ObjectiveService
{
    public static async Task<List<Objective>> GetObjectivesByColumnIdAsync(int idColumn)
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseApiUrl}/Objective/column/{idColumn}");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Objective>>(data);
    }
}