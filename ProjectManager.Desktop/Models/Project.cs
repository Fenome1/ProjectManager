using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager;
using static ProjectManager.Desktop.ViewModels.Manager.ManagerViewModel;

namespace ProjectManager.Desktop.Models;

public partial class Project : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Board>? _boards;

    [ObservableProperty] private int _idAgency;
    [ObservableProperty] private int _idProject;
    [ObservableProperty] private string _name = null!;

    public ICommand DeleteProjectCommand => new RelayCommand(async () =>
    {
        await ProjectService.DeleteAsync(IdProject);
    });

}