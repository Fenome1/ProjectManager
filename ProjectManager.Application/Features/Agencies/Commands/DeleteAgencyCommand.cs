using MediatR;
using ProjectManager.Core.Models;

namespace ProjectManager.Application.Features.Agencies.Commands;

public class DeleteAgencyCommand : IRequest<Agency>
{
    public int IdAgency { get; set; }
}