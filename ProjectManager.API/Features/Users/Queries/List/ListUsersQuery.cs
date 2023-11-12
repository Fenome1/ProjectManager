using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Queries.List;

public class ListUsersQuery : BaseQuery<List<User>>
{
    public ListUsersQuery(bool isDeleted)
    {
        IncludeDeleted = isDeleted;
    }
}