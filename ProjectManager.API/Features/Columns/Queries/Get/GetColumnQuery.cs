using ProjectManager.API.Features.Base.Queries;
using ProjectManager.API.Models;

namespace ProjectManager.API.Features.Columns.Queries.Get;

public class GetColumnQuery : BaseQuery<Column>
{
    public GetColumnQuery(int idColumn, bool isDelete)
    {
        IdColumn = idColumn;
        IncludeDeleted = isDelete;
    }

    public int IdColumn { get; set; }
}