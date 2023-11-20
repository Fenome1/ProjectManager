using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
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

    public static async Task<bool> CreateAsync(string login, string password, int role)
    {
        try
        {
            var response = await $"{BaseApiUrl}/User"
                .PostJsonAsync(new { Login = login, Password = password, Role = role });

            if (response.ResponseMessage.IsSuccessStatusCode) return true;
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
        }

        return false;
    }

    public static async Task<bool> UpdateAsync(int idUser,
        string? login = null,
        string? password = null,
        string? firstName = null,
        string? lastName = null,
        int? theme = null,
        byte[]? image = null,
        bool isImageReset = false)
    {
        var updatingUser = new
        {
            IdUser = idUser,
            Login = login,
            Password = password,
            FirstName = firstName,
            LastName = lastName,
            Theme = theme,
            Image = image,
            IsImageReset = isImageReset
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

    public static async Task<User> AuthAsync(string login, string password)
    {
        var data = new { Login = login, Password = password };

        try
        {
            var response = await $"{BaseApiUrl}/User/Login"
                .PostJsonAsync(data);

            if (response.ResponseMessage.IsSuccessStatusCode)
            {
                var userJson = await response.ResponseMessage.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(userJson);

                return user;
            }
        }
        catch (FlurlHttpException ex)
        {
            if (ex.StatusCode == (int)FtpStatusCode.ServiceNotAvailable)
                MessageBox.Show("Ошибка, подключения к серверу");
            Console.WriteLine($"Произошла ошибка при выполнении запроса: {ex.Message}");
        }

        return null;
    }

    public static async Task<bool> DeleteAsync(int idUser)
    {
        try
        {
            var response = await $"{BaseApiUrl}/User/{idUser}"
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