using MediatR;
using ProjectManager.API.Data;
using ProjectManager.API.Features.Agency.Commands;

namespace ProjectManager.API.Features.Agency.Handlers;

public class UpdateAgencyCommandHandler : IRequestHandler<UpdateAgencyCommand, Models.Agency>
{
    private readonly ProjectManagerDbContext _context;

    public UpdateAgencyCommandHandler(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Models.Agency> Handle(UpdateAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = await _context.Agencies.FindAsync(request.IdAgency);

        if (agency is null)
        {
            //Валидация
            return null;
        }

        if (!string.IsNullOrWhiteSpace(request.Name))
            agency.Name = request.Name;

        if (request.Description is not null || request.Description?.Trim() == "")
            agency.Description = request.Description;

        await _context.SaveChangesAsync();

        //Валидация мб
        return agency;
    }
}