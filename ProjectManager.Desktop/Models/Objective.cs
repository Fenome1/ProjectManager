using System;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ProjectManager.Desktop.Models.Enums;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Edit;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Special;

namespace ProjectManager.Desktop.Models;

public partial class Objective : ObservableObject
{
    [ObservableProperty] private DateTime? _deadline;

    [ObservableProperty] private string? _description;

    [ObservableProperty] private int _idColumn;
    [ObservableProperty] private int _idObjective;

    [ObservableProperty] private string _name = null!;

    [JsonProperty("IdPriorityNavigation")] [ObservableProperty]
    private Priority? _priority;

    [ObservableProperty] private bool _status;

    public ICommand UpdateStatusCommand => new RelayCommand(async () =>
    {
        await ObjectiveService.UpdateAsync(IdObjective, status: Status);
    });

    public ICommand UpdateObjectiveCommand => new RelayCommand(async () =>
    {
        var objectiveUpdateWindow = new ObjectiveUpdateWindow(this);
        objectiveUpdateWindow.ShowDialog();

        if (!(bool)objectiveUpdateWindow.DialogResult!)
            return;

        await ObjectiveService.UpdateAsync(IdObjective,
            name: objectiveUpdateWindow.NameTextBox.Text,
            description: objectiveUpdateWindow.DescriptionTextBox.Text);
    });

    public ICommand DeleteObjectiveCommand => new RelayCommand(async () =>
    {
        var isDeleteQuestion = MessageBox.Show("Удалить задачу?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (isDeleteQuestion == MessageBoxResult.Yes)
            await ObjectiveService.DeleteAsync(IdObjective);
    });

    public ICommand DeadlineSelectCommand => new RelayCommand(async () =>
    {
        var selectWindow = new DeadlineSelectWindow(Deadline);

        selectWindow.ShowDialog();

        if (!(bool)selectWindow.DialogResult)
            return;

        var selectedDeadline = selectWindow.DeadlineDate;

        await ObjectiveService.UpdateAsync(IdObjective, deadline: selectedDeadline);
    });

    public ICommand DeadlineRemoveCommand => new RelayCommand(async () =>
    {
        await ObjectiveService.UpdateAsync(IdObjective, isDeadlineReset: true);
    });

    public ICommand ExecutorSelectCommand
        => new RelayCommand(async () =>
        {
            var executors = await UserService.GetByRoleAsync((int)Roles.Executor);
            var selectWindow = new ExecutorSelectWindow(executors, IdObjective);
            selectWindow.ShowDialog();
        });
}