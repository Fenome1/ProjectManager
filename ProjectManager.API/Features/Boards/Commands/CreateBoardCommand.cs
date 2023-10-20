using MediatR;
using ProjectManager.API.Models;

public class CreateBoardCommand : IRequest<Board>
{
    public int IdProject { get; set; }
    public string Name { get; set; }

}