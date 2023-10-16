using MediatR;
using ProjectManager.Application.Features.Agencies.Commands;
using ProjectManager.Core.Models;
using ProjectManager.Persistence.Context;

namespace ProjectManager.Application.Features.Agencies.Handlers;

public class DeleteAgencyCommandHandler : IRequestHandler<DeleteAgencyCommand, Agency>
{
    private readonly ProjectManagerDbContext _context;

    public DeleteAgencyCommandHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Agency> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = await _context.Agencies.FindAsync(request.IdAgency);

        if (agency == null)
            //Валидацию сюда
            return null;

        _context.Agencies.Remove(agency);
        await _context.SaveChangesAsync();

        return agency;
    }
}