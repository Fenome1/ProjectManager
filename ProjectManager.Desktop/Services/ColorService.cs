using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.Data.URL;

namespace ProjectManager.Desktop.Services;

public static class ColorService
{
    public static async Task<List<Color>?> GetColorsAsync()
    {
        try
        {
            var response = await $"{BaseApiUrl}/Color"
                .GetJsonAsync<List<Color>>();

            return response;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }
}