using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.Data.URL;

namespace ProjectManager.Desktop.Services;

internal static class ProjectService
{
    public static async Task<List<Project>?> GetProjectsByAgencyIdAsync(int idAgency, bool isDeleted = false)
    {
        using var httpClient = new HttpClient();

        var response =
            await httpClient.GetAsync($"{BaseApiUrl}/Project/agency/{idAgency}?{nameof(isDeleted)}={isDeleted}");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Project>>(data);
    }

    public static async Task<Project?> GetAsync(int idProject, bool isDeleted = false)
    {
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"{BaseApiUrl}/Project/{idProject}?{nameof(isDeleted)}={isDeleted}");

        if (!response.IsSuccessStatusCode) return null;

        var data = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Project>(data);
    }

    public static async Task<bool> CreateProjectAsync(int idAgency, string name)
    {
        using var httpClient = new HttpClient();

        var data = new { idAgency, name };

        try
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseApiUrl}/Project", data);
            if (response.IsSuccessStatusCode) return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка создания проекта: {ex.Message}");
        }

        return false;
    }
    public static async Task<bool> DeleteAsync(int idProject)
    {
        using var httpClient = new HttpClient();

        try
        {
            var response = await httpClient.DeleteAsync($"{BaseApiUrl}/Project/{idProject}");
            if (response.IsSuccessStatusCode)
                return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка удаления проекта: {ex.Message}");
        }

        return false;
    }
}