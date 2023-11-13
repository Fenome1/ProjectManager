using System;
using System.Windows;
using System.Windows.Input;
using ProjectManager.Desktop.Common.Config.Executor;
using static ProjectManager.Desktop.ViewModels.Executor.ExecutorViewModel;

namespace ProjectManager.Desktop.View.Executor;

/// <summary>
///     Логика взаимодействия для ExecutorWindow.xaml
/// </summary>
public partial class ExecutorWindow : Window
{
    public ExecutorWindow()
    {
        InitializeComponent();
        DataContext = ExecutorVm;
        var _ = new SignalRExecutorClient().Start();
    }

    private async void ExecutorWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await ExecutorVm.InitializeUser();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            Close();
        }
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
}