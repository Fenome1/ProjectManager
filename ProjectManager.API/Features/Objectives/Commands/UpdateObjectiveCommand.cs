using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Commands;

public class UpdateObjectiveCommand : IRequest<Objective>
{
    public int IdObjective { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? IdPriority { get; set; }
    public DateTime? Deadline { get; set; }
    public bool? Status { get; set; }
    public bool IsDeadlineReset { get; set; } = false;
    public bool IsPriorityReset { get; set; } = false;
}