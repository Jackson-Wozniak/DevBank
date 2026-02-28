using DevNote.API.Data;
using DevNote.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevNote.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EntryController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult Test()
    {
        context.Add(new Entry());
        context.Add(new Entry());
        context.SaveChanges();
        return Ok(new JsonResult(context.Entries.ToList()));
    }
}