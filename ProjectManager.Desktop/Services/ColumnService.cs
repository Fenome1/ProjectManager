using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.Data.URL;

namespace ProjectManager.Desktop.Services;

public static class ColumnService
{
    public static async Task<List<Column>?> GetListByBoardIdAsync(int idBoard)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Column/Board/{idBoard}"
                .GetJsonAsync<List<Column>>();

            return response;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public static async Task<Column?> GetAsync(int idColumn, bool isDeleted = false)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Column/{idColumn}"
                .SetQueryParam(nameof(isDeleted), isDeleted)
                .GetJsonAsync<Column>();

            return response;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public static async Task<bool> CreateAsync(int idBoard, string name)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Column"
                .PostJsonAsync(new { idBoard, name });

            if (response.ResponseMessage.IsSuccessStatusCode)
                return true;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
        }

        return false;
    }

    public static async Task<bool> DeleteAsync(int idColumn)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Column/{idColumn}"
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

    public static async Task<bool> UpdateAsync(int idColumn, int? idColor = null, string? name = null)
    {
        var updatingColumn = new
        {
            IdColumn = idColumn,
            IdColor = idColor,
            Name = name
        };

        try
        {
            var response = await $"{BaseApiUrl}/Column"
                .PutJsonAsync(updatingColumn);

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