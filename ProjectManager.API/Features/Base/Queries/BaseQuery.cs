using MediatR;

namespace ProjectManager.API.Features.Base.Queries;

public abstract class BaseQuery<TResponse> : IRequest<TResponse>
{
    public bool IncludeDeleted { get; set; } = false;
}