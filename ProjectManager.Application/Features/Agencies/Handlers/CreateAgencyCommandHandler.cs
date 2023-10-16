using MediatR;
using ProjectManager.Application.Features.Agency.Commands;
using ProjectManager.Persistence.Context;

namespace ProjectManager.Application.Features.Agency.Handlers;

public class CreateAgencyCommandHandler : IRequestHandler<CreateAgencyCommand, Core.Models.Agency>
{
    private readonly ProjectManagerDbContext _context;

    public CreateAgencyCommandHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Core.Models.Agency> Handle(CreateAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = new Core.Models.Agency
        {
            Name = request.Name,
            Description = request.Description
        };

        _context.Agencies.Add(agency);
        await _context.SaveChangesAsync(cancellationToken);

        return agency;
    }
}