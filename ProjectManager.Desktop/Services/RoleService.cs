using Flurl.Http;
using ProjectManager.Desktop.Common.Data;
using ProjectManager.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManager.Desktop.Services;

public class RoleService
{
    internal async static Task<List<Role>?> GetRolesAsync()
    {
        try
        {
            var response = await $"{URL.BaseApiUrl}/Role"
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