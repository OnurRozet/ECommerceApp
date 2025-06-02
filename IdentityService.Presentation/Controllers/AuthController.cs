using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}