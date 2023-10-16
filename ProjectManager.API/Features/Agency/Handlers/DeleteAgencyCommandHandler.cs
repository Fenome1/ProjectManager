using MediatR;
using ProjectManager.API.Data;
using ProjectManager.API.Features.Agency.Commands;

namespace ProjectManager.API.Features.Agency.Handlers;

public class DeleteAgencyCommandHandler : IRequestHandler<DeleteAgencyCommand, Models.Agency>
{
    private readonly ProjectManagerDbContext _context;

    public DeleteAgencyCommandHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }
    public async Task<Models.Agency> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = await _context.Agencies.FindAsync(request.IdAgency);

        if (agency == null)
        {
            //Валидацию сюда
            return null;
        }

        _context.Agencies.Remove(agency);
        await _context.SaveChangesAsync();

        return agency;
    }
}