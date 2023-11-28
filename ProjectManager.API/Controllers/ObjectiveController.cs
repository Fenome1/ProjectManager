using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Features.Objectives.Commands;
using ProjectManager.API.Features.Objectives.Queries.Get;
using ProjectManager.API.Features.Objectives.Queries.List;
using ProjectManager.API.Features.Objectives.Queries.List.ByColumn;

namespace ProjectManager.API.Controllers;

public class ObjectiveController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get(bool isDeleted = false)
    {
        var query = new ListObjectivesQuery(isDeleted);
        var objectives = await Mediator.Send(query);

        return Ok(objectives);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, bool isDeleted = false)
    {
        var query = new GetObjectiveQuery(id, isDeleted);
        var objectives = await Mediator.Send(query);

        return Ok(objectives);
    }

    [HttpGet("Column/{idColumn}")]
    public async Task<IActionResult> GetByColumn(int idColumn, bool isDeleted = false)
    {
        var query = new ListObjectivesByColumnQuery(idColumn, isDeleted);
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("User/{idUser}")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateObjectiveCommand command)
    {
        var result = await Mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = result.IdColumn }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateObjectiveCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteObjectiveCommand { IdObjective = id };
        await Mediator.Send(command);

        return NoContent();
    }
}