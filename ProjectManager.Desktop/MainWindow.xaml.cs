using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ProjectManager.API.Models;

namespace ProjectManager.Desktop;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private List<Agency> _agencies;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;

        var sq = new SignalRClient(this);
        sq.Start();
    }

    public List<Agency> Agencies
    {
        get => _agencies;
        set
        {
            _agencies = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public void UpdateAgencies(List<Agency> updatedAgencies)
    {
        Agencies = updatedAgencies;
    }

    private async void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
    {
        Agencies = await SignalRClient.UpdateAgencies();
    }
}