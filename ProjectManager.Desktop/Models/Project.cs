using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Edit;

namespace ProjectManager.Desktop.Models;

public partial class Project : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Board>? _boards;

    [ObservableProperty] private int _idAgency;
    [ObservableProperty] private int _idProject;
    [ObservableProperty] private string _name = null!;

    public ICommand DeleteProjectCommand => new RelayCommand(async () =>
    {
        var isDeleteQuestion = MessageBox.Show("Удалить проект?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (isDeleteQuestion != MessageBoxResult.Yes)
            return;

        await ProjectService.DeleteAsync(IdProject);
    });

    public ICommand UpdateProjectCommand => new RelayCommand(async () =>
    {
        var projectUpdateWindow = new ProjectUpdateWindow(this);
        projectUpdateWindow.ShowDialog();

        if (!(bool)projectUpdateWindow.DialogResult!)
            return;

        var isDeleteQuestion = MessageBox.Show("Удалить проект?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (isDeleteQuestion == MessageBoxResult.Yes)
            await ProjectService.UpdateAsync(IdProject,
            projectUpdateWindow.NameTextBox.Text);
    });
}