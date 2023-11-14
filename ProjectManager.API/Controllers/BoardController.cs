using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Features.Boards.Commands;
using ProjectManager.API.Features.Boards.Queries.Get;
using ProjectManager.API.Features.Boards.Queries.List;
using ProjectManager.API.Features.Boards.Queries.List.ByProject;

namespace ProjectManager.API.Controllers;

public class BoardController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get(bool isDeleted = false)
    {
        var query = new ListBoardsQuery(isDeleted);
        var projects = await Mediator.Send(query);

        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, bool isDeleted = false)
    {
        var query = new GetBoardQuery(id, isDeleted);
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("Project/{idProject}")]
    public async Task<IActionResult> GetByProjectId(int idProject, bool isDeleted = false)
    {
        var query = new ListBoardsByProjectQuery(idProject, isDeleted);
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBoardCommand command)
    {
        var result = await Mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id = result.IdBoard }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBoardCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteBoardCommand(id);
        await Mediator.Send(command);

        return NoContent();
    }
}