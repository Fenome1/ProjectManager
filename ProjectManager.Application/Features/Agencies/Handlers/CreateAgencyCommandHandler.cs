using MediatR;
using ProjectManager.Application.Features.Agencies.Commands;
using ProjectManager.Core.Models;
using ProjectManager.Persistence.Context;

namespace ProjectManager.Application.Features.Agencies.Handlers;

public class CreateAgencyCommandHandler : IRequestHandler<CreateAgencyCommand, Agency>
{
    private readonly ProjectManagerDbContext _context;

    public CreateAgencyCommandHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Agency> Handle(CreateAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = new Agency
        {
            Name = request.Name,
            Description = request.Description
        };

        _context.Agencies.Add(agency);
        await _context.SaveChangesAsync(cancellationToken);

        return agency;
    }
}