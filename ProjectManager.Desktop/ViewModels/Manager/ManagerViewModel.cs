using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop.ViewModels.Manager;

public partial class ManagerViewModel : ViewModelBase
{
    [ObservableProperty] private List<Agency> _agencies = new();
    [ObservableProperty] private Project? _selectedProject;
    private bool _isPrimaryTheme = true;


    public ManagerViewModel()
    {
        Instance = this;
    }

    public static ManagerViewModel Instance { get; set; } = new();

    public async Task LoadAgenciesAsync()
    {
        var agencies = await AgencyService.UpdateAgencies();

        if (agencies is null)
            return;

        Agencies = agencies;

        foreach (var agency in Agencies)
            await agency.LoadProjectsAsync();
    }

    public async Task LoadProjectsAsync(int idAgency)
    {
        var agency = Agencies.First(a => a.IdAgency == idAgency);

        var projects = await ProjectService.GetProjectsByAgencyIdAsync(idAgency);
        agency.Projects = projects;

        if (SelectedProject != null) await LoadProjectTree(SelectedProject);
    }

    public async Task LoadBoardsAsync(int idProject)
    {
        var project = Agencies.SelectMany(a => a.Projects!).First(p => p.IdProject == idProject);

        var boards = await BoardService.GetBoardsByProjectIdAsync(idProject);
        project.Boards = boards;

        if (SelectedProject != null) await LoadProjectTree(SelectedProject);
    }

    public async Task LoadColumnsAsync(int idBoard)
    {
        var board = Agencies
            .SelectMany(a => a.Projects!)
            .SelectMany(p => p.Boards!)
            .First(b => b.IdBoard == idBoard);

        var columns = await ColumnService.GetColumnsByBoardIdAsync(idBoard);
        board.Columns = columns;

        if (SelectedProject != null) await LoadProjectTree(SelectedProject);
    }

    public async Task LoadObjectivesAsync(int idColumn)
    {
        var column = Agencies
            .SelectMany(a => a.Projects!)
            .SelectMany(p => p.Boards!)
            .SelectMany(c => c.Columns!)
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

            foreach (var column in columns) 
                await column.LoadObjectivesAsync();
        }
    }

    public static void ChangeTheme()
    {
        var path = "/View/Styles/Themes";

        if (Instance._isPrimaryTheme)
        {
            path += "/SecondaryThemeDictionary.xaml";
            Instance._isPrimaryTheme = false;
        }
        else
        {
            path += "/PrimaryThemeDictionary.xaml";
            Instance._isPrimaryTheme = true;
        }

        var resourceDict = Application.LoadComponent(new Uri(path, UriKind.Relative)) as ResourceDictionary;
        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(resourceDict);
    }
}