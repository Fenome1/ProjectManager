using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Create;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Edit;
using ProjectManager.Desktop.ViewModels.Manager;

namespace ProjectManager.Desktop.Models;

public partial class Agency : ObservableObject
{
    [ObservableProperty] private string? _description;
    [ObservableProperty] private int _idAgency;

    [ObservableProperty] private string _name = null!;

    [ObservableProperty] private ObservableCollection<Project>? _projects;

    public ICommand CreateNewProjectCommand => new RelayCommand(async () =>
    {
        var createProjectDialogWindow = new CreateObjectDialogWindow("Создать проект");
        createProjectDialogWindow.ShowDialog();

        if (!createProjectDialogWindow.DialogResult!.Value) return;

        var projectName = createProjectDialogWindow.EnteredText.Trim();

        if (!string.IsNullOrEmpty(projectName))
            await ProjectService.CreateAsync(IdAgency, projectName);
    });

    public ICommand UpdateAgencyCommand => new RelayCommand(async () =>
    {
        var agencyUpdateWindow = new AgencyUpdateWindow(this);
        agencyUpdateWindow.ShowDialog();

        if (!(bool)agencyUpdateWindow.DialogResult!)
            return;

        await AgencyService.UpdateAsync(IdAgency,
            agencyUpdateWindow.NameTextBox.Text,
            agencyUpdateWindow.DescriptionTextBox.Text);
    });

    public ICommand DeleteAgencyCommand => new RelayCommand(async () =>
    {
        if (ManagerViewModel.ManagerVm.Agencies.Count <= 1)
        {
            MessageBox.Show("Невозможно удалить последнее агентство",
                "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            return;
        }

        await AgencyService.DeleteAsync(IdAgency);
    });
}