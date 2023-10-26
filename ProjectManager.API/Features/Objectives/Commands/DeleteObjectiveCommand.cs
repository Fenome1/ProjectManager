using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Commands;

public class DeleteObjectiveCommand : IRequest<Objective>
{
    public int IdObjective { get; set; }
}