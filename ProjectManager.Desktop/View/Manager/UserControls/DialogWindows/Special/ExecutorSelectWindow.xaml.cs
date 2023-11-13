using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ProjectManager.Desktop.Models;

namespace ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Special;

public partial class ExecutorSelectWindow : Window, INotifyPropertyChanged
{
    private List<User> _executors;
    private int _idObjective;

    public ExecutorSelectWindow(List<User> executors, int idObjective)
    {
        Executors = executors;
        IdObjective = idObjective;
        InitializeComponent();
        DataContext = this;
    }

    public List<User> Executors
    {
        get => _executors;
        set
        {
            _executors = value;
            OnPropertyChanged();
        }
    }

    public int IdObjective
    {
        get => _idObjective;
        set
        {
            _idObjective = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}