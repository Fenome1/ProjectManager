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

public static class ColumnService
{
    public static async Task<List<Column>?> GetColumnsByBoardIdAsync(int idBoard)
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseApiUrl}/Column/board/{idBoard}");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Column>>(data);
    }

    public static async Task<Column?> GetAsync(int idColumn, bool isDeleted = false)
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseApiUrl}/Column/{idColumn}?{nameof(isDeleted)}={isDeleted}");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Column>(data);
    }

    public static async Task<bool> CreateColumnAsync(int idBoard, string name)
    {
        using var httpClient = new HttpClient();

        var data = new { idBoard, name };

        try
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseApiUrl}/Column", data);
            if (response.IsSuccessStatusCode) return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка создания колонки: {ex.Message}");
        }

        return false;
    }
}