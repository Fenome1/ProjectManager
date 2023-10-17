using MediatR;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Agencies.Queries;

public class GetAgencyQueryHandler : IRequestHandler<GetAgencyQuery, Agency>
{
    private readonly ProjectManagerDbContext _context;

    public GetAgencyQueryHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Agency?> Handle(GetAgencyQuery request, CancellationToken cancellationToken)
    {
        var agency = await _context.Agencies.FindAsync(request.IdAgency);

        return agency;
    }
}