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

    public static async Task<Board> GetAsync(int idBoard, bool isDeleted = false)
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseApiUrl}/Board/{idBoard}?{nameof(isDeleted)}={isDeleted}");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Board>(data);
    }

    public static async Task<bool> DeleteAsync(int idBoard)
    {
        using var httpClient = new HttpClient();

        try
        {
            var response = await httpClient.DeleteAsync($"{BaseApiUrl}/Board/{idBoard}");
            if (response.IsSuccessStatusCode)
                return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка удаления доски: {ex.Message}");
        }

        return false;
    }
}