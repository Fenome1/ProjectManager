namespace ProjectManager.Desktop.Common;

public static class URL
{
    public static string BaseUrl => "https://localhost:7172";
    public static string BaseHubUrl => $"{BaseUrl}/notifyHub";
    public static string BaseApiUrl => $"{BaseUrl}/api";
}