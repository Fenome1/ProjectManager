using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop.Models;

public partial class Project : ObservableObject
{
    [ObservableProperty] private List<Board> _boards;
    public int IdProject { get; set; }
    public string Name { get; set; }
    private int IdAgency { get; set; }

    public async Task LoadBoardsAsync()
    {
        var boards = await BoardsService.GetBoardsByProjectIdAsync(IdProject);
        Boards = boards;
    }
}