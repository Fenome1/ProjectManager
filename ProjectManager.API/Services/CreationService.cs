using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Services;

public static class CreationService
{
    public static async Task<Board> CreateNewBoardForProjectAsync(this ProjectManagerDbContext context, int idProject)
    {
        var newBoard = new Board { Name = "Новая доска", IdProject = idProject };
        await context.Boards.AddAsync(newBoard);
        await context.SaveChangesAsync();
        return newBoard;
    }

    public static async Task<Column> CreateNewColumnForBoardAsync(this ProjectManagerDbContext context, int idBoard)
    {
        var newColumn = new Column { Name = "Новая колонка", IdBoard = idBoard };
        await context.Columns.AddAsync(newColumn);
        await context.SaveChangesAsync();
        return newColumn;
    }
}