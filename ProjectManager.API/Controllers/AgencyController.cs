using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Features.Agency.Commands;
using ProjectManager.Application.Features.Agency.Queries;
using ProjectManager.Core.Models;

namespace ProjectManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgencyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AgencyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetAgencyQuery { IdAgency = id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Agency>>> Get()
        {
            var query = new ListAgenciesQuery();
            var agencies = await _mediator.Send(query);
            return Ok(agencies);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAgencyCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id = result.IdAgency }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAgencyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAgencyCommand { IdAgency = id };
            await _mediator.Send(command);
            // Валидация
            return NoContent();
        }
    }
}