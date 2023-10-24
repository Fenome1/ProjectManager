using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop.Models;

public partial class Board : ObservableObject
{
    [ObservableProperty] private List<Column> _columns;
    public int IdBoard { get; set; }
    public string Name { get; set; } = null!;
    public int IdProject { get; set; }

    public async Task LoadColumnsAsync()
    {
        var columns = await ColumnService.GetColumnsByBoardIdAsync(IdBoard);
        Columns = columns;
    }
}