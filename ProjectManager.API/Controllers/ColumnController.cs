using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Features.Columns.Commands;
using ProjectManager.API.Features.Columns.Queries.List;
using ProjectManager.API.Features.Columns.Queries.List.ByBoard;

namespace ProjectManager.API.Controllers;

public class ColumnController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new ListColumnsQuery();
        var columns = await Mediator.Send(query);

        return Ok(columns);
    }

    [HttpGet("board/{idProject}")]
    public async Task<IActionResult> GetByProjectId(int idProject)
    {
        var query = new ListColumnsByBoardQuery { IdBoard = idProject };
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateColumnCommand command)
    {
        var result = await Mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = result.IdColumn }, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteColumnCommand { IdColumn = id };
        await Mediator.Send(command);

        return NoContent();
    }
}