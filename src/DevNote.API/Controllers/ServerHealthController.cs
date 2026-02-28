using Microsoft.AspNetCore.Mvc;

namespace DevNote.API.Controllers;

[ApiController]
[Route("api/healthcheck")]
public class ServerHealthController: ControllerBase
{
    [HttpGet]
    public ActionResult<bool> IsResponsive()
    {
        return Ok();
    }
}