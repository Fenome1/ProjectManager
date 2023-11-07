using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.Features.Colors.List;

namespace ProjectManager.API.Controllers;

public class ColorController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new ListColorsQuery();
        var colors = await Mediator.Send(query);
        return Ok(colors);
    }
}