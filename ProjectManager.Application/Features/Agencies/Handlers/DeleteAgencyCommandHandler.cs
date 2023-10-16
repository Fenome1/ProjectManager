using MediatR;
using ProjectManager.Application.Features.Agency.Commands;
using ProjectManager.Persistence.Context;

namespace ProjectManager.Application.Features.Agency.Handlers
{
    public class DeleteAgencyCommandHandler : IRequestHandler<DeleteAgencyCommand, Core.Models.Agency>
    {
        private readonly ProjectManagerDbContext _context;

        public DeleteAgencyCommandHandler(ProjectManagerDbContext context)
        {
            _context = context;
        }
        public async Task<Core.Models.Agency> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
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
}