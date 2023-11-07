using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Autofac;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Common.Config;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Create;
using ProjectManager.Desktop.ViewModels.Base;

namespace ProjectManager.Desktop.ViewModels.Manager;

public partial class ManagerViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<Agency> _agencies = new();

    private bool _isPrimaryTheme = true;

    [ObservableProperty] private Project? _selectedProject;

    public ManagerViewModel()
    {
        ManagerVm = this;
    }

    public static ManagerViewModel ManagerVm { get; private set; } = new();
    private IMapper Mapper => AppConfig.Container.Resolve<IMapper>();

    //commands
    public ICommand ChangeThemeCommand => new RelayCommand(() =>
    {
        var path = "/View/Styles/Themes";

        if (_isPrimaryTheme)
        {
            path += "/SecondaryThemeDictionary.xaml";
            _isPrimaryTheme = false;
        }
        else
        {
            path += "/PrimaryThemeDictionary.xaml";
            _isPrimaryTheme = true;
        }

        var resourceDict = Application.LoadComponent(new Uri(path, UriKind.Relative)) as ResourceDictionary;
        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(resourceDict);
    });

    //Agency notifications
    public ICommand CreateNewAgencyCommand => new RelayCommand(async () =>
    {
        var createAgencyDialogWindow = new CreateObjectDialogWindow();
        createAgencyDialogWindow.ShowDialog();

        if (!createAgencyDialogWindow.DialogResult!.Value) return;

        var agencyName = createAgencyDialogWindow.EnteredText.Trim();

        if (!string.IsNullOrEmpty(agencyName))
            await AgencyService.CreateAgencyAsync(agencyName);
    });

    //Columns notifications
    public ICommand ColumnColorUpdateCommand => new RelayCommand<(int idColumn, int idColor)>(async columnColorUpdate =>
    {
        await ColumnService.UpdateColumn(columnColorUpdate.idColumn, columnColorUpdate.idColor);
    });

    //Objectives notifications
    public ICommand ObjectivePriorityUpdateCommand =>
        new RelayCommand<(int idObjective, int idPriority)>(async updateCommand =>
        {
            if (updateCommand.idPriority < 0)
            {
                await ObjectiveService.UpdateAsync(updateCommand.idObjective, isPriorityReset: true);
                return;
            }

            await ObjectiveService.UpdateAsync(updateCommand.idObjective, updateCommand.idPriority);
        });

    //loadTree
    public async Task LoadTreeAsync()
    {
        var agencies = await AgencyService.GetAsync();

        if (agencies is null || !agencies.Any())
            return;

        foreach (var agency in agencies)
            Agencies.Add(agency);
    }

    public async Task CreateAgencyAsync(int idAgency)
    {
        var createdAgency = await AgencyService.GetAsync(idAgency);

        if (createdAgency is null) return;

        Application.Current.Dispatcher.Invoke(() => { Agencies.Add(createdAgency); });
    }

    public async Task UpdateAgencyAsync(int idAgency)
    {
        var updatedAgency = await AgencyService.GetAsync(idAgency);

        if (updatedAgency is null) return;

        var agencyToUpdate = GetAgencyByProject(updatedAgency.IdAgency);

        if (agencyToUpdate is null) return;

        Application.Current.Dispatcher.Invoke(() =>
        {
            Mapper.Map(updatedAgency, agencyToUpdate);
            OnPropertyChanged(nameof(Agencies));
        });
    }

    public void DeleteAgencyAsync(int idAgency)
    {
        var deletedAgency = GetAgencyByProject(idAgency);

        if (deletedAgency is null) return;

        Application.Current.Dispatcher.Invoke(() => { Agencies.Remove(deletedAgency); });
    }

    //Project notifications
    public async Task CreateProjectAsync(int idProject)
    {
        var createdProject = await ProjectService.GetAsync(idProject);

        if (createdProject is null) return;

        var agency = GetAgencyByProject(createdProject.IdAgency);

        if (agency is null) return;

        Application.Current.Dispatcher.Invoke(() => { agency.Projects.Add(createdProject); });
    }

    public async Task UpdateProjectAsync(int idProject)
    {
        var updatedProject = await ProjectService.GetAsync(idProject);

        if (updatedProject is null)
            return;

        var agency = GetAgencyByProject(updatedProject.IdAgency);

        var oldItemInCollection =
            agency.Projects.FirstOrDefault(p => p.IdProject == updatedProject.IdProject);

        if (oldItemInCollection != null) Mapper.Map(updatedProject, oldItemInCollection);
    }

    public async Task DeleteProjectAsync(int idProject)
    {
        var deletedProject = await ProjectService.GetAsync(idProject, true);

        var agency = GetAgencyByProject(deletedProject.IdAgency);

        if (agency is null) return;

        var currentProjectInCollection =
            agency.Projects.FirstOrDefault(p => p.IdProject == idProject);

        if (currentProjectInCollection is null)
            return;

        Application.Current.Dispatcher.Invoke(() => { agency.Projects.Remove(currentProjectInCollection); });

        if (SelectedProject.IdProject == deletedProject.IdProject)
            Application.Current.Dispatcher.Invoke(() => { ManagerVm.SelectedProject = null; });
    }

    private Agency? GetAgencyByProject(int idAgency)
    {
        return Agencies.FirstOrDefault(a => a.IdAgency == idAgency);
    }

    //Boards notifications
    public async Task CreateBoardAsync(int idBoard)
    {
        var createdBoard = await BoardService.GetAsync(idBoard);

        if (createdBoard is null) return;

        var project = GetProjectByBoard(createdBoard.IdProject);

        if (project is null) return;

        Application.Current.Dispatcher.Invoke(() => { project.Boards.Add(createdBoard); });
    }

    public async Task UpdateBoardAsync(int idBoard)
    {
        var updatedBoard = await BoardService.GetAsync(idBoard);

        if (updatedBoard is null) return;

        var project = GetProjectByBoard(updatedBoard.IdProject);

        if (project is null) return;

        var boardToUpdate = project.Boards
            .FirstOrDefault(p => p.IdBoard == updatedBoard.IdBoard);

        if (boardToUpdate is null) return;

        Application.Current.Dispatcher.Invoke(() => { Mapper.Map(updatedBoard, boardToUpdate); });
    }

    public async Task DeleteBoardAsync(int idBoard)
    {
        var deletedBoard = await BoardService.GetAsync(idBoard, true);

        if (deletedBoard is null) return;

        var project = GetProjectByBoard(deletedBoard.IdProject);

        if (project is null) return;

        var currentBoardInCollection = project.Boards
            .FirstOrDefault(b => b.IdBoard == deletedBoard.IdBoard);

        if (currentBoardInCollection is null) return;

        Application.Current.Dispatcher.Invoke(() => { project.Boards.Remove(currentBoardInCollection); });
    }

    private Project? GetProjectByBoard(int idProject)
    {
        return Agencies
            .SelectMany(a => a.Projects)
            .FirstOrDefault(p => p.IdProject == idProject);
    }

    public async Task CreateColumnAsync(int idColumn)
    {
        var createdColumn = await ColumnService.GetAsync(idColumn);

        if (createdColumn is null) return;

        var board = GetBoardByColumn(createdColumn.IdBoard);

        if (board is null) return;

        Application.Current.Dispatcher.Invoke(() => { board.Columns.Add(createdColumn); });
    }

    public async Task UpdateColumnAsync(int idColumn)
    {
        var updatedColumn = await ColumnService.GetAsync(idColumn);

        if (updatedColumn is null) return;

        var board = GetBoardByColumn(updatedColumn.IdBoard);

        if (board is null) return;

        var columnToUpdate = board.Columns
            .FirstOrDefault(c => c.IdColumn == updatedColumn.IdColumn);

        if (columnToUpdate is null) return;

        Application.Current.Dispatcher.Invoke(() =>
        {
            Mapper.Map(updatedColumn, columnToUpdate);
            OnPropertyChanged(nameof(Column));
        });
    }

    public async Task DeleteColumnAsync(int idColumn)
    {
        var deletedColumn = await ColumnService.GetAsync(idColumn, true);

        if (deletedColumn is null) return;

        var board = GetBoardByColumn(deletedColumn.IdBoard);

        if (board is null) return;

        var currentColumnInCollection = board.Columns
            .FirstOrDefault(c => c.IdColumn == deletedColumn.IdColumn);

        if (currentColumnInCollection is null) return;

        Application.Current.Dispatcher.Invoke(() => { board.Columns.Remove(currentColumnInCollection); });
    }

    private Board? GetBoardByColumn(int idBoard)
    {
        return Agencies
            .SelectMany(a => a.Projects)
            .SelectMany(p => p.Boards)
            .FirstOrDefault(b => b.IdBoard == idBoard);
    }

    public async Task CreateObjectiveAsync(int idObjective)
    {
        var createdObjective = await ObjectiveService.GetAsync(idObjective);

        if (createdObjective is null) return;

        var column = GetColumnByObjective(createdObjective.IdColumn);

        if (column is null) return;

        Application.Current.Dispatcher.Invoke(() => { column.Objectives.Add(createdObjective); });
    }

    public async void UpdateObjectiveAsync(int idObjective)
    {
        var updatedObjective = await ObjectiveService.GetAsync(idObjective);

        if (updatedObjective is null) return;

        var column = GetColumnByObjective(updatedObjective.IdColumn);

        if (column is null) return;

        var objectiveToUpdate = column.Objectives
            .FirstOrDefault(c => c.IdObjective == updatedObjective.IdObjective);

        if (objectiveToUpdate is null) return;

        Application.Current.Dispatcher.Invoke(() =>
        {
            Mapper.Map(updatedObjective, objectiveToUpdate);
            OnPropertyChanged(nameof(Objective));
        });
    }

    public async Task DeleteObjectiveAsync(int idObjective)
    {
        var deletedObjective = await ObjectiveService.GetAsync(idObjective, true);

        if (deletedObjective is null) return;

        var column = GetColumnByObjective(deletedObjective.IdColumn);

        if (column is null) return;

        var currentObjectiveInCollection = column.Objectives
            .FirstOrDefault(c => c.IdObjective == deletedObjective.IdObjective);

        if (currentObjectiveInCollection is null) return;

        Application.Current.Dispatcher.Invoke(() => { column.Objectives.Remove(currentObjectiveInCollection); });
    }

    private Column? GetColumnByObjective(int idColumn)
    {
        return Agencies
            .SelectMany(a => a.Projects)
            .SelectMany(p => p.Boards)
            .SelectMany(c => c.Columns)
            .FirstOrDefault(c => c.IdColumn == idColumn);
    }
}