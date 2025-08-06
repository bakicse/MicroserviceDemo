using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceB.Controllers;

[ApiController]
[Route("CallServiceA")]
public class CallServiceAController(IHttpClientFactory httpClientFactory) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var httpClient = httpClientFactory.CreateClient("ServiceAClient");

        try
        {
            var response = await httpClient.GetStringAsync("https://localhost:7283/Message");
            return Ok($"Hello from ServiceB! ServiceA says: {response}");
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, $"Error calling ServiceA: {ex.Message}");
        }
    }
}
