using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.Data.URL;

namespace ProjectManager.Desktop.Services;

public static class AgencyService
{
    public static async Task<List<Agency>?> GetAsync(bool isDeleted = false)
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseApiUrl}/Agency?{nameof(isDeleted)}={isDeleted}");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Agency>>(data);
    }

    public static async Task<Agency> GetAsync(int idAgency, bool isDeleted = false)
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseApiUrl}/Agency/{idAgency}?{nameof(isDeleted)}={isDeleted}");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Agency>(data);
    }

    public static async Task<bool> CreateAgencyAsync(string name)
    {
        using var httpClient = new HttpClient();

        try
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseApiUrl}/Agency", new {name});
            if (response.IsSuccessStatusCode) return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка создания агенства: {ex.Message}");
        }

        return false;
    }
    public static async Task<bool> DeleteAsync(int idAgency)
    {
        using var httpClient = new HttpClient();

        try
        {
            var response = await httpClient.DeleteAsync($"{BaseApiUrl}/Agency/{idAgency}");
            if (response.IsSuccessStatusCode)
                return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка удаления агенства: {ex.Message}");
        }

        return false;
    }
}