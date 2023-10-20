
using MediatR;
using ProjectManager.API.Models;

public class DeleteBoardCommand : IRequest<Board>
{
    public int IdBoard { get; set; }
}