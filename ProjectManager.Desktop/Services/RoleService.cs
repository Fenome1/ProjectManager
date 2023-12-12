using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using ProjectManager.Desktop.Common.Data;
using ProjectManager.Desktop.Models;

namespace ProjectManager.Desktop.Services;

public class RoleService
{
    internal static async Task<List<Role>?> GetRolesAsync()
    {
        try
        {
            var response = await $"{Url.BaseApiUrl}/Role"
                .GetJsonAsync<List<Role>?>();

            return response;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }
}