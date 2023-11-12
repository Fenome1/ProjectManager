using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Features.Roles.List;

namespace ProjectManager.API.Controllers;

public class RoleController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new ListRolesQuery();
        var roles = await Mediator.Send(query);
        return Ok(roles);
    }
}