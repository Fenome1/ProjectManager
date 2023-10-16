using MediatR;
using ProjectManager.Core.Models;
using ProjectManager.Persistence.Context;

namespace ProjectManager.Application.Features.Agencies.Queries;

public class GetAgencyQueryHandler : IRequestHandler<GetAgencyQuery, Agency>
{
    private readonly ProjectManagerDbContext _context;

    public GetAgencyQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Agency> Handle(GetAgencyQuery request, CancellationToken cancellationToken)
    {
        var agency = await _context.Agencies.FindAsync(request.IdAgency);

        if (agency == null)
            throw new Exception("Агенство не найдено");

        return agency;
    }
}