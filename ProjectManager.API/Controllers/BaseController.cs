using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
