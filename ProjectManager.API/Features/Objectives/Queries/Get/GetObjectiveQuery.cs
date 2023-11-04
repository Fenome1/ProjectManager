using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Queries.Get;

public class GetObjectiveQuery : BaseQuery<Objective>
{
    public GetObjectiveQuery(int idObjective, bool isDeleted)
    {
        IdObjective = idObjective;
        IncludeDeleted = isDeleted;
    }

    public int IdObjective { get; }
}