using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Models.Enums;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Special;

public partial class ExecutorSelectWindow : Window, INotifyPropertyChanged
{
    private List<User> _executors;

    private int _idObjective;
    private List<User> _tempUsers;

    public ExecutorSelectWindow(List<User> executors, int idObjective)
    {
        Executors = executors;
        _tempUsers = Executors;

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

    private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        FilterUsers();
    }

    private void FilterUsers()
    {
        var filterText = FilterTextBox.Text;

        if (string.IsNullOrWhiteSpace(filterText))
        {
            Executors = _tempUsers;
            return;
        }

        if (_tempUsers is null || !_tempUsers.Any())
            return;

        var filteredUsers =
            _tempUsers.Where(u => u.Login.Contains(filterText,
                StringComparison.CurrentCultureIgnoreCase)).ToList();

        Executors = filteredUsers;
    }

    private async Task UpdateExecutors()
    {
        await Task.Delay(100);
        _tempUsers = await UserService.GetByRoleAsync((int)Roles.Executor);
        FilterUsers();
    }

    private async void AssignCheckBox_OnClick(object sender, RoutedEventArgs e)
    {
        await UpdateExecutors();
    }
}