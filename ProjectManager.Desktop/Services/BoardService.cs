using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using ProjectManager.Desktop.Models;
using static ProjectManager.Desktop.Common.Data.URL;

namespace ProjectManager.Desktop.Services;

public static class BoardService
{
    public static async Task<List<Board>?> GetBoardsByProjectIdAsync(int idProject)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Board/project/{idProject}"
                .GetJsonAsync<List<Board>>();

            return response;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public static async Task<Board> GetAsync(int idBoard, bool isDeleted = false)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Board/{idBoard}"
                .SetQueryParam(nameof(isDeleted), isDeleted)
                .GetJsonAsync<Board>();

            return response;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public static async Task<bool> CreateAsync(int idProject, string name)
    {
        var data = new { idProject, name };

        try
        {
            var response = await $"{BaseApiUrl}/Board"
                .PostJsonAsync(data);

            if (response.ResponseMessage.IsSuccessStatusCode) return true;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
        }

        return false;
    }

    public static async Task<bool> DeleteAsync(int idBoard)
    {
        try
        {
            var response = await $"{BaseApiUrl}/Board/{idBoard}"
                .DeleteAsync();

            if (response.ResponseMessage.IsSuccessStatusCode) return true;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
        }

        return false;
    }

    public static async Task<bool> UpdateAsync(int idBoard, string name)
    {
        var updatingBoard = new
        {
            IdBoard = idBoard,
            Name = name
        };

        try
        {
            var response = await $"{BaseApiUrl}/Board"
                .PutJsonAsync(updatingBoard);

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