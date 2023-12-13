namespace ProjectManager.Desktop.Common.Data;

public static class Url
{
    private static string BaseUrl => $"http://localhost:8080";
    public static string BaseHubUrl => $"{BaseUrl}/notifyHub";
    public static string BaseApiUrl => $"{BaseUrl}/Api";
}