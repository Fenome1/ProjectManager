namespace ProjectManager.Desktop.Common.Data;

public static class Url
{
    private static string ServerUrl => "5.35.83.160"; 
    private static string Deploy => $"http://{ServerUrl}:8080";
    private static string Develop => "https://localhost:7172";
    public static string BaseUrl => Deploy;
    public static string BaseHubUrl => $"{BaseUrl}/notifyHub";
    public static string BaseApiUrl => $"{BaseUrl}/Api";
}