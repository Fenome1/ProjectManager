using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.Data.URL;

namespace ProjectManager.Desktop.Services;

public static class AgencyService
{
    public static async Task<List<Agency>?> GetAsync(bool isDeleted = false)
    {
        try
        {
            var agencies = await $"{BaseApiUrl}/Agency"
                .SetQueryParam(nameof(isDeleted), isDeleted)
                .GetJsonAsync<List<Agency>>();

            return agencies;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public static async Task<Agency> GetAsync(int idAgency, bool isDeleted = false)
    {
        try
        {
            var agency = await $"{BaseApiUrl}/Agency/{idAgency}"
                .SetQueryParam(nameof(isDeleted), isDeleted)
                .GetJsonAsync<Agency>();

            return agency;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public static async Task<bool> CreateAsync(string name, string description = null)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Agency"
                .PostJsonAsync(new { Name = name, Description = description });

            if (response.ResponseMessage.IsSuccessStatusCode) return true;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
        }

        return false;
    }

    public static async Task<bool> DeleteAsync(int idAgency)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Agency/{idAgency}"
                .DeleteAsync();

            if (response.ResponseMessage.IsSuccessStatusCode) return true;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
        }

        return false;
    }

    public static async Task<bool> UpdateAsync(int idAgency, string? name = null, string? description = null)
    {
        var updatingProject = new
        {
            IdAgency = idAgency,
            Name = name,
            Description = description
        };

        try
        {
            var response = await $"{BaseApiUrl}/Agency"
                .PutJsonAsync(updatingProject);

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