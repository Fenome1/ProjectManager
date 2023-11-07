using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Create;

namespace ProjectManager.Desktop.Models;

public partial class Agency : ObservableObject
{
    [ObservableProperty] private string? _description;
    [ObservableProperty] private int _idAgency;

    [ObservableProperty] private string _name = null!;

    [ObservableProperty] private ObservableCollection<Project>? _projects;

    public ICommand CreateNewProjectCommand => new RelayCommand(async () =>
    {
        var createProjectDialogWindow = new CreateObjectDialogWindow();
        createProjectDialogWindow.ShowDialog();

        if (!createProjectDialogWindow.DialogResult!.Value) return;

        var projectName = createProjectDialogWindow.EnteredText.Trim();

        if (!string.IsNullOrEmpty(projectName))
            await ProjectService.CreateProjectAsync(IdAgency, projectName);
    });

    public ICommand DeleteAgencyCommand => new RelayCommand(async () => { await AgencyService.DeleteAsync(IdAgency); });
}