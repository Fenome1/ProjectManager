using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Users.Queries.Get;

public class GetUserQuery : BaseQuery<User>
{
    public GetUserQuery(int idUser, bool isDeleted)
    {
        IdUser = idUser;
        IncludeDeleted = isDeleted;
    }

    public int IdUser { get; private set; }
}