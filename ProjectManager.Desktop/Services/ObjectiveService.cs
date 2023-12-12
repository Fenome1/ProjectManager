using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.Data.Url;

namespace ProjectManager.Desktop.Services;

public static class ObjectiveService
{
    public static async Task<List<Objective>?> GetListByColumnIdAsync(int idColumn)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Objective/Column/{idColumn}"
                .GetJsonAsync<List<Objective>>();

            return response;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public static async Task<Objective?> GetAsync(int idObjective, bool isDeleted = false)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Objective/{idObjective}"
                .SetQueryParam(nameof(isDeleted), isDeleted)
                .GetJsonAsync<Objective>();

            return response;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public static async Task<bool> CreateAsync(int idColumn, string name)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Objective"
                .PostJsonAsync(new { idColumn, name });

            if (response.ResponseMessage.IsSuccessStatusCode)
                return true;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
        }

        return false;
    }

    public static async Task<bool> DeleteAsync(int idObjective)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Objective/{idObjective}"
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

    public static async Task<bool> UpdateAsync(int idObjective,
        int? idPriority = null,
        string? name = null,
        string? description = null,
        DateTime? deadline = null,
        bool? status = null,
        bool isPriorityReset = false,
        bool isDeadlineReset = false)
    {
        try
        {
            var updatingObjective = new
            {
                IdObjective = idObjective,
                IdPriority = idPriority,
                Name = name,
                Description = description,
                Deadline = deadline,
                Status = status,
                IsPriorityReset = isPriorityReset,
                IsDeadlineReset = isDeadlineReset
            };

            var response = await $"{BaseApiUrl}/Objective"
                .PutJsonAsync(updatingObjective);

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