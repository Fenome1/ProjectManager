using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Features.Columns.Commands;
using ProjectManager.API.Features.Columns.Queries.Get;
using ProjectManager.API.Features.Columns.Queries.List;
using ProjectManager.API.Features.Columns.Queries.List.ByBoard;

namespace ProjectManager.API.Controllers;

public class ColumnController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get(bool isDeleted = false)
    {
        var query = new ListColumnsQuery(isDeleted);
        var columns = await Mediator.Send(query);

        return Ok(columns);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, bool isDeleted = false)
    {
        var query = new GetColumnQuery(id, isDeleted);
        var columns = await Mediator.Send(query);

        return Ok(columns);
    }

    [HttpGet("Board/{idBoard}")]
    public async Task<IActionResult> GetByBoardId(int idBoard, bool isDeleted = false)
    {
        var query = new ListColumnsByBoardQuery(idBoard, isDeleted);
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateColumnCommand command)
    {
        var result = await Mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = result.IdColumn }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateColumnCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteColumnCommand { IdColumn = id };
        await Mediator.Send(command);

        return NoContent();
    }
}