using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectManager.Desktop.ViewModels.Base;

public class ViewModelBase : ObservableObject
{
    public ViewModelBase()
    {
        Instance = this;
    }

    public static ViewModelBase Instance { get; set; } = new();
}