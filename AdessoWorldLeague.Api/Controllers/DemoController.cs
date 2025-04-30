using Microsoft.AspNetCore.Mvc;

namespace AdessoWorldLeague.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemoController : ControllerBase
{
    [HttpGet("hello")]
    public IActionResult Hello()
    {
        return Ok("Hello from DemoController!");
    }
} 