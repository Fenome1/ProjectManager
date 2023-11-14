using System;
using System.Windows;
using System.Windows.Input;
using ProjectManager.Desktop.Common.Config.Executor;
using static ProjectManager.Desktop.ViewModels.Executor.ExecutorViewModel;

namespace ProjectManager.Desktop.View.Executor;

public partial class ExecutorWindow : Window
{
    private readonly SignalRExecutorClient _signalRExecutorClient;

    public ExecutorWindow()
    {
        InitializeComponent();
        DataContext = ExecutorVm;
        _signalRExecutorClient = new SignalRExecutorClient();
    }

    private async void ExecutorWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (ExecutorVm.User is null)
        {
            MessageBox.Show("Ошибка авторизации");
            Close();
        }

        await _signalRExecutorClient.StartConnection();
    }

    private void DragWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void WindowSizeChange_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized;
    }

    private void HideWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void CloseWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Close();
    }

    private async void ExecutorWindow_OnClosed(object? sender, EventArgs e)
    {
        await _signalRExecutorClient.StopConnection();
    }
}