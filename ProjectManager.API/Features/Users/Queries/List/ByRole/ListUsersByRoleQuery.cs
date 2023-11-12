using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Queries.List.ByRole;

public class ListUsersByRoleQuery : BaseQuery<List<User>>
{
    public int Role { get; set; }
    public ListUsersByRoleQuery(int role, bool isDeleted)
    {
        Role = role;
        IncludeDeleted = isDeleted;
    }
}