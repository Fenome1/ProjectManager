using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Features.Users.Commands;
using ProjectManager.API.Features.Users.Commands.Objectives.Add;
using ProjectManager.API.Features.Users.Commands.Objectives.Delete;
using ProjectManager.API.Features.Users.Queries.Get;
using ProjectManager.API.Features.Users.Queries.List;
using ProjectManager.API.Features.Users.Queries.List.ByRole;

namespace ProjectManager.API.Controllers;

public class UserController : BaseController
{
    [HttpGet]
    public async Task<ActionResult> Get(bool isDeleted = false)
    {
        var query = new ListUsersQuery(isDeleted);
        var user = await Mediator.Send(query);

        return user.Any() ? Ok(user) : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, bool isDeleted = false)
    {
        var query = new GetUserQuery(id, isDeleted);
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("Role/{id}")]
    public async Task<IActionResult> GetByRole(int id, bool isDeleted = false)
    {
        var query = new ListUsersByRoleQuery(id, isDeleted);
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var result = await Mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id = result.IdUser }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("Objectives/Add")]
    public async Task<IActionResult> Create([FromBody] AddObjectiveToUserCommand command)
    {
        var result = await Mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id = result.IdUser }, result);
    }

    [HttpPut("Objectives/Delete")]
    public async Task<IActionResult> Create([FromBody] DeleteObjectiveToUserCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand { IdUser = id };
        await Mediator.Send(command);

        return NoContent();
    }
}