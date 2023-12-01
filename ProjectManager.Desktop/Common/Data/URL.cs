namespace ProjectManager.Desktop.Common.Data;

public static class URL
{
    private static string Deploy => "http://localhost:8080";
    private static string Develop => "https://localhost:7172";
    public static string BaseUrl => Develop;
    public static string BaseHubUrl => $"{BaseUrl}/notifyHub";
    public static string BaseApiUrl => $"{BaseUrl}/Api";
}