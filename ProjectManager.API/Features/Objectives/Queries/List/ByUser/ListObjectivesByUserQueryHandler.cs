/*using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Objectives.Queries.List.ByUser;

public class ListObjectivesByUserQueryHandler : IRequestHandler<ListObjectivesByUserQuery,List<Objective>>
{
    private readonly ProjectManagerDbContext _context;

    public ListObjectivesByUserQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Objective>> Handle(ListObjectivesByUserQuery request, CancellationToken cancellationToken)
    {
        var user = _context.Users.FirstOrDefault(u => u.IdUser == request.IdUser);

        if (user is null)
        {
            throw new Exception("Пользователь не найден");
        }

        var objectives = await _context.Objectives
            .Include(o => o.IdPriorityNavigation)
            .Where(o => o.IsDeleted == request.IncludeDeleted)
            .Where(o => o.IdUsers.Contains(user))
            .ToListAsync();

        if (!objectives.Any())
        {
            throw new Exception("Задачи для пользователя не найдены");
        }

        return objectives;
    }
}*/

