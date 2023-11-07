using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Features.Priorities.List;

namespace ProjectManager.API.Controllers;

public class PriorityController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new ListPriorityQuery();
        var priorities = await Mediator.Send(query);
        return Ok(priorities);
    }
}