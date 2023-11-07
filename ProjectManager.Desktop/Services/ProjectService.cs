using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.Data.URL;

namespace ProjectManager.Desktop.Services;

public static class ProjectService
{
    public static async Task<List<Project>?> GetProjectsByAgencyIdAsync(int idAgency, bool isDeleted = false)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Project/agency/{idAgency}"
                .SetQueryParam(nameof(isDeleted), isDeleted)
                .GetJsonAsync<List<Project>>();

            return response;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public static async Task<Project?> GetAsync(int idProject, bool isDeleted = false)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Project/{idProject}"
                .SetQueryParam(nameof(isDeleted), isDeleted)
                .GetJsonAsync<Project>();

            return response;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public static async Task<bool> CreateProjectAsync(int idAgency, string name)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Project"
                .PostJsonAsync(new { idAgency, name });

            if (response.ResponseMessage.IsSuccessStatusCode)
                return true;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
        }

        return false;
    }

    public static async Task<bool> DeleteAsync(int idProject)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Project/{idProject}"
                .DeleteAsync();

            if (response.ResponseMessage.IsSuccessStatusCode)
                return true;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
        }

        return false;
    }
}