using static BCrypt.Net.BCrypt;

namespace ProjectManager.API.Services;

public class HashService
{
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string inputPassword, string hashedPassword)
    {
        return Verify(inputPassword, hashedPassword);
    }
}