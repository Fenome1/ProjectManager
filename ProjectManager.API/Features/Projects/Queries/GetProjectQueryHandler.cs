using MediatR;
using ProjectManager.API.Context;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Projects.Queries
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, Project>
    {
        private readonly ProjectManagerDbContext _context;

        public GetProjectQueryHandler(ProjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Project> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FindAsync(request.IdProject);

            if (project == null)
                throw new Exception("Проект не найден");

            return project;
        }
    }
}
