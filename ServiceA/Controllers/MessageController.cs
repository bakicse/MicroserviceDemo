using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceA.Controllers;

[ApiController]
[Route("Message")]
public class MessageController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello from ServiceA!");
    }
}
