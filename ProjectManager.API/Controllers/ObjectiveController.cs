using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Features.Objectives.Commands;
using ProjectManager.API.Features.Objectives.Queries.List;
using ProjectManager.API.Features.Objectives.Queries.List.ByColumn;

namespace ProjectManager.API.Controllers;

public class ObjectiveController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new ListObjectivesQuery();
        var objectives = await Mediator.Send(query);

        return Ok(objectives);
    }

    [HttpGet("column/{idColumn}")]
    public async Task<IActionResult> GetByProjectId(int idColumn)
    {
        var query = new ListObjectivesByColumnQuery { IdColumn = idColumn };
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateObjectiveCommand command)
    {
        var result = await Mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = result.IdColumn }, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteObjectiveCommand { IdObjective = id };
        await Mediator.Send(command);

        return NoContent();
    }
}