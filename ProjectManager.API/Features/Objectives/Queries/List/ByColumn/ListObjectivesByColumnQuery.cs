using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Queries.List.ByColumn;

public class ListObjectivesByColumnQuery : IRequest<List<Objective>>
{
    public int IdColumn { get; set; }
}