using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Features.Agencies.Commands;
using ProjectManager.API.Features.Agencies.Queries.Get;
using ProjectManager.API.Features.Agencies.Queries.List;
using ProjectManager.API.Models;

namespace ProjectManager.API.Controllers;

public class AgencyController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<List<Agency>>> Get(bool isDeleted = false)
    {
        var query = new ListAgenciesQuery(isDeleted);
        var agencies = await Mediator.Send(query);

        return agencies.Any() ? Ok(agencies) : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, bool isDeleted = false)
    {
        var query = new GetAgencyQuery(id, isDeleted);
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAgencyCommand command)
    {
        var result = await Mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id = result.IdAgency }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAgencyCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteAgencyCommand { IdAgency = id };
        await Mediator.Send(command);

        return NoContent();
    }
}