using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.Data.URL;

namespace ProjectManager.Desktop.Services;

internal static class ProjectService
{
    public static async Task<List<Project>?> GetProjectsByAgencyIdAsync(int idAgency)
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseApiUrl}/Project/agency/{idAgency}");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Project>>(data);
    }
}