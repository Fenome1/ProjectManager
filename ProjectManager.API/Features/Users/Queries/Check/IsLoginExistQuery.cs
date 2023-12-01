using ProjectManager.API.Features.Base.Queries;

namespace ProjectManager.API.Features.Users.Queries.Check;

public class IsLoginExistQuery : BaseQuery<bool>
{
    public IsLoginExistQuery(string login, bool isDeleted)
    {
        Login = login;
        IncludeDeleted = isDeleted;
    }

    public string Login { get; set; }
}