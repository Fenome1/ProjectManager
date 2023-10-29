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

    public static async Task<bool> CreateObjectiveAsync(int idColumn, string name)
    {
        using var httpClient = new HttpClient();

        var data = new { idColumn, name };

        try
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseApiUrl}/Objective", data);
            if (response.IsSuccessStatusCode)
                return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка создания задачи: {ex.Message}");
        }

        return false;
    }
}