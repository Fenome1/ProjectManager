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

public static class BoardService
{
    public static async Task<List<Board>?> GetBoardsByProjectIdAsync(int idProject)
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseApiUrl}/Board/project/{idProject}");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Board>>(data);
    }

    public static async Task<bool> CreateBoardAsync(int idProject, string name)
    {
        using var httpClient = new HttpClient();

        var data = new { idProject, name };

        try
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseApiUrl}/Board", data);
            if (response.IsSuccessStatusCode) return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка создания доски: {ex.Message}");
        }

        return false;
    }
}