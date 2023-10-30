using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.Data.URL;

namespace ProjectManager.Desktop.Services;

public static class PriorityService
{
    public static async Task<List<Priority>?> GetPrioritiesAsync()
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseApiUrl}/Priority");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Priority>>(data);
    }
}