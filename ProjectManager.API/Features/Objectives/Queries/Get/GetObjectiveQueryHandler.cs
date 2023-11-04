using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Queries.Get;

public class GetObjectiveQueryHandler : IRequestHandler<GetObjectiveQuery, Objective>
{
    private readonly ProjectManagerDbContext _context;

    public GetObjectiveQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Objective> Handle(GetObjectiveQuery request, CancellationToken cancellationToken)
    {
        var objective = await _context.Objectives
            .Where(o => o.IsDeleted == request.IncludeDeleted)
            .Include(o => o.IdPriorityNavigation)
            .FirstOrDefaultAsync(o => o.IdObjective == request.IdObjective);

        if (objective is null)
            throw new Exception("Задача не найдена");

        return objective;
    }
}