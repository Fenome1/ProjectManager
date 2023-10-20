using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.URL;

namespace ProjectManager.Desktop.Services;

public static class AgencyService
{
    public static async Task<List<Agency>> UpdateAgencies()
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseUrl}/Agency");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Agency>>(data);
    }
}