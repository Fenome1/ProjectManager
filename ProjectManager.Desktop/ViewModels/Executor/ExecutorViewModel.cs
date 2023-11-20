using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Autofac;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using ProjectManager.Desktop.Common.Config;
using ProjectManager.Desktop.Common.Handlers;
using ProjectManager.Desktop.Models;
using ProjectManager.Desktop.Models.Enums;
using ProjectManager.Desktop.Services;
using ProjectManager.Desktop.View.General;
using ProjectManager.Desktop.ViewModels.Base;

namespace ProjectManager.Desktop.ViewModels.Executor;

public partial class ExecutorViewModel : ViewModelBase, IDisposable
{
    [ObservableProperty] private User? _user;

    public ExecutorViewModel()
    {
        ExecutorVm = this;
    }

    private IMapper Mapper => AppConfig.Container.Resolve<IMapper>();
    public static ExecutorViewModel ExecutorVm { get; private set; } = new();

    //commands
    public ICommand ChangeThemeCommand => new RelayCommand(async () =>
    {
        var profileEditWindow = new ProfileEditWindow();
        profileEditWindow.ShowDialog();
    });

    //profile
    public ICommand UploadProfilePhotoCommand => new RelayCommand(async () =>
    {
        var openFileDialog = new OpenFileDialog();

        openFileDialog.DefaultExt = ".png";
        openFileDialog.Filter =
            "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|All files (*.*)|*.*";

        if (!(bool)openFileDialog.ShowDialog())
            return;

        var filename = openFileDialog.FileName;

        try
        {
            var data = File.ReadAllBytes(filename);

            if (data is null)
                return;

            await UserService.UpdateAsync(_user.IdUser, image: data);
        }
        catch (Exception)
        {
            //--
        }
    });

    public ICommand ClearProfilePhotoCommand => new RelayCommand(async () =>
    {
        await UserService.UpdateAsync(_user.IdUser, isImageReset: true);
    });

    public void Dispose()
    {
        User = null;

        ThemeManager.SetTheme(Themes.Primary);

        GC.SuppressFinalize(true);
    }


    //Assign
    public async Task ObjectiveAddAssignAsync(int idObjective)
    {
        var assignObjective = await ObjectiveService.GetAsync(idObjective);

        if (assignObjective is null)
            return;

        Application.Current.Dispatcher.Invoke(() => { User.IdObjectives.Add(assignObjective); });
    }

    public async Task ObjectiveDeleteAssignAsync(int idObjective)
    {
        var assignObjective = await ObjectiveService.GetAsync(idObjective);

        if (assignObjective is null)
            return;

        var currentObjective = User.IdObjectives
            .FirstOrDefault(o => o.IdObjective == idObjective);

        if (currentObjective is null)
            return;

        Application.Current.Dispatcher.Invoke(() => { User.IdObjectives.Remove(currentObjective); });
    }

    public async Task UpdateObjectiveAsync(int idObjective)
    {
        var updatedObjective = await ObjectiveService.GetAsync(idObjective);

        if (updatedObjective is null) return;

        var objectiveToUpdate = User.IdObjectives
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

        var currentObjectiveInCollection = User.IdObjectives
            .FirstOrDefault(c => c.IdObjective == deletedObjective.IdObjective);

        if (currentObjectiveInCollection is null) return;

        Application.Current.Dispatcher.Invoke(() => { User.IdObjectives.Remove(currentObjectiveInCollection); });
    }

    public async Task GetObjectivesAsync()
    {
        var currentUser = await UserService.GetAsync(User.IdUser);

        if (currentUser is null) return;

        var newObjectives = currentUser.IdObjectives;

        Application.Current.Dispatcher.Invoke(() =>
        {
            User.IdObjectives.Clear();
            User.IdObjectives = newObjectives;
        });
    }

    public async Task UpdateUserAsync(int idUser)
    {
        var updatedUser = await UserService.GetAsync(idUser);

        Application.Current.Dispatcher.Invoke(() =>
        {
            Mapper.Map(updatedUser, _user);
            OnPropertyChanged(nameof(User));
        });
    }
}