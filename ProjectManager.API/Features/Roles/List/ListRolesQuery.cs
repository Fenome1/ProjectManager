using MediatR;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Roles.List;

public class ListRolesQuery : IRequest<List<Role>> { }