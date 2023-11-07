using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.Data.URL;

namespace ProjectManager.Desktop.Services;

public static class PriorityService
{
    public static async Task<List<Priority>?> GetPrioritiesAsync()
    {
        try
        {
            var response = await $"{BaseApiUrl}/Priority"
                .GetJsonAsync<List<Priority>?>();

            return response;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }
}