using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectManager.Desktop.Models;

public partial class Agency : ObservableObject
{
    [ObservableProperty] private string? _description;
    [ObservableProperty] private int _idAgency;

    [ObservableProperty] private string _name = null!;

    [ObservableProperty] private ObservableCollection<Project>? _projects;
}