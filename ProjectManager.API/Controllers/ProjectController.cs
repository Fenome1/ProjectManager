using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Features.Projects.Commands;
using ProjectManager.API.Features.Projects.Queries.ByAgency;
using ProjectManager.API.Features.Projects.Queries.Get;
using ProjectManager.API.Features.Projects.Queries.List;

namespace ProjectManager.API.Controllers;

public class ProjectController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get(bool isDeleted = false)
    {
        var query = new ListProjectsQuery(isDeleted);
        var projects = await Mediator.Send(query);

        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, bool isDeleted = false)
    {
        var query = new GetProjectQuery(id, isDeleted);
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("agency/{idAgency}")]
    public async Task<IActionResult> GetByAgencyId(int idAgency, bool isDeleted = false)
    {
        var query = new ListProjectsByAgencyQuery(idAgency, isDeleted);
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
    {
        var result = await Mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id = result.IdProject }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProjectCommand command)
    {
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProjectCommand { IdProject = id };
        await Mediator.Send(command);

        return NoContent();
    }
}