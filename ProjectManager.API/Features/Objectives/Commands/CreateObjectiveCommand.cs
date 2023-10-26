using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Commands;

public class CreateObjectiveCommand : IRequest<Objective>
{
    public string Name { get; set; } = null!;
    public int IdColumn { get; set; }
}