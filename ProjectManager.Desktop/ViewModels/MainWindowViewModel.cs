using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private List<Agency> _agencies = new();
    [ObservableProperty] private Project _selectedProject;

    public MainWindowViewModel()
    {
        Instance = this;
    }

    public static MainWindowViewModel Instance { get; set; } = new();

    public async Task LoadAgenciesAsync()
    {
        var agencies = await AgencyService.UpdateAgencies();
        Agencies = agencies;
    }

    public async Task LoadProjectsAsync(int idAgency)
    {
        var agency = Agencies.First(a => a.IdAgency == idAgency);

        var projects = await ProjectService.GetProjectsByAgencyIdAsync(idAgency);
        agency.Projects = projects;
    }

    public async Task LoadBoardsAsync(int idProject)
    {
        var project = Agencies.SelectMany(a => a.Projects).First(p => p.IdProject == idProject);
        var boards = await BoardsService.GetBoardsByProjectIdAsync(idProject);
        project.Boards = boards;
    }
}