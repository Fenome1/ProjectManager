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
        var boards = await BoardService.GetBoardsByProjectIdAsync(idProject);
        project.Boards = boards;
    }

    public async Task LoadColumnsAsync(int idBoard)
    {
        var board = Agencies
            .SelectMany(a => a.Projects)
            .SelectMany(p => p.Boards)
            .First(b => b.IdBoard == idBoard);

        var columns = await ColumnService.GetColumnsByBoardIdAsync(idBoard);
        board.Columns = columns;
    }

    public async Task LoadObjectivesAsync(int idColumn)
    {
        var column = Agencies
            .SelectMany(a => a.Projects)
            .SelectMany(p => p.Boards)
            .SelectMany(c => c.Columns)
            .First(c => c.IdColumn == idColumn);

        var objectives = await ObjectiveService.GetObjectivesByColumnIdAsync(idColumn);
        column.Objectives = objectives;
    }

    public static async Task LoadProjectTree(Project project)
    {
        var boards = project.Boards;

        if (boards is null || !boards.Any())
            return;

        foreach (var board in boards)
        {
            await board.LoadColumnsAsync();

            var columns = board.Columns;

            if (columns is null || !columns.Any())
                return;

            foreach (var column in board.Columns) await column.LoadObjectivesAsync();
        }
    }
}