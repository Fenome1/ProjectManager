using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManager.Desktop.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManager.Desktop.Models;

public partial class Project : ObservableObject
{
    public int IdProject { get; set; }
    public string Name { get; set; }
    private int IdAgency { get; set; }

    [ObservableProperty] private List<Board> _boards;

    public async Task LoadBoardsAsync()
    {
        var boards = await BoardsService.GetBoardsByProjectIdAsync(IdProject);
        Boards = boards;
    }

}