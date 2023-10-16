using MediatR;
using ProjectManager.API.Data;
using ProjectManager.API.Features.Agency.Commands;

namespace ProjectManager.API.Features.Agency.Handlers;

public class CreateAgencyCommandHandler : IRequestHandler<CreateAgencyCommand, Models.Agency>
{
    private readonly ProjectManagerDbContext _context;

    public CreateAgencyCommandHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Models.Agency> Handle(CreateAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = new Models.Agency
        {
            Name = request.Name,
            Description = request.Description
        };

        _context.Agencies.Add(agency);
        await _context.SaveChangesAsync(cancellationToken);

        return agency;
    }
}