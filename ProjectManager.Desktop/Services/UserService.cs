using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using Flurl;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Models.Enums;
using static ProjectManager.Desktop.Common.Data.URL;

namespace ProjectManager.Desktop.Services;

public class UserService
{
    public static async Task<List<User>?> GetAsync(bool isDeleted = false)
    {
        try
        {
            var users = await $"{BaseApiUrl}/User"
                .SetQueryParam(nameof(isDeleted), isDeleted)
                .GetJsonAsync<List<User>>();

            return users;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }
    public static async Task<User> GetAsync(int idUser, bool isDeleted = false)
    {
        try
        {
            var user = await $"{BaseApiUrl}/User/{idUser}"
                .SetQueryParam(nameof(isDeleted), isDeleted)
                .GetJsonAsync<User>();

            return user;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }
    public static async Task<List<User>> GetByRoleAsync(int idRole, bool isDeleted = false)
    {
        try
        {
            var user = await $"{BaseApiUrl}/User/Role/{idRole}"
                .SetQueryParam(nameof(isDeleted), isDeleted)
                .GetJsonAsync<List<User>>();

            return user;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
            return null;
        }
    }

    public static async Task<bool> UpdateAsync(int idUser,
        string? login = null,
        string? password = null,
        string? fullName = null,
        int? theme = null,
        string? image = null)
    {
        var updatingUser = new
        {
            IdUser = idUser,
            Login = login,
            Password = password,
            FullName = fullName,
            Theme = theme,
            Image = image
        };
        try
        {
            var response = await $"{BaseApiUrl}/User"
                .PutJsonAsync(updatingUser);

            if (response.ResponseMessage.IsSuccessStatusCode)
                return true;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
        }

        return false;
    }

    public static async Task<bool> UpdateAssignAsync(int idUser, int idObjective, Operation operation)
    {
        try
        {
            var response = await $"{BaseApiUrl}/User/Objectives/{operation}"
                .PutJsonAsync(new { IdUser = idUser, IdObjective = idObjective });

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