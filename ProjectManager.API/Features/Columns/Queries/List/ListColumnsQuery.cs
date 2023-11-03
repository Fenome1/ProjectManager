using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Queries.List;

public class ListColumnsQuery : BaseQuery<List<Column>>
{
    public ListColumnsQuery(bool isDeleted)
    {
        IncludeDeleted = isDeleted;
    }
}