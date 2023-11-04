using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectManager.Desktop.Models;

public partial class Project : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Board>? _boards;

    [ObservableProperty] private int _idAgency;
    [ObservableProperty] private int _idProject;
    [ObservableProperty] private string _name = null!;
}