using System.Windows;

namespace ProjectManager.Desktop;

public partial class App : Application
{
    /*public bool IsServerConnected(string serverAddress, int port)
    {
        try
        {
            using var client = new TcpClient(serverAddress, port);
            return true;
        }
        catch (SocketException)
        {
            return false;
        }
    }*/
    /*public bool IsNetworkAvailable()
    {
        return NetworkInterface.GetIsNetworkAvailable();
    }*/

    /*protected override void OnLoadCompleted(NavigationEventArgs e)
    {

    }*/
    /* public void CheckAndReconnect()
     {
         if (IsNetworkAvailable() && IsServerConnected("your_server_address", your_port))
         {
             // Код для работы с контекстом при наличии подключения
         }
         else
         {
             MessageBoxResult result = MessageBox.Show("Нет подключения к контексту. Хотите переподключиться?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

             if (result == MessageBoxResult.Yes)
             {
                 // Код для переподключения
             }
             else
             {
                 // Обработка отказа от переподключения
             }
         }
     }*/
}