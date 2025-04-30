using AdessoWorldLeague.Application.DTOs;
using AdessoWorldLeague.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdessoWorldLeague.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrawController : ControllerBase
{
    private readonly IDrawService _drawService;

    public DrawController(IDrawService drawService)
    {
        _drawService = drawService;
    }

    [HttpPost("draw")]
    public async Task<IActionResult> Draw([FromBody] DrawRequestDto request)
    {
        if (request.GroupCount != 4 && request.GroupCount != 8)
        {
            return BadRequest("Group count must be either 4 or 8.");
        }

        var result = await _drawService.DrawGroupsAsync(request.GroupCount, request.DrawnBy);
        return Ok(result);
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("API is working!");
    }
} 