using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        return Ok(new
        {
            Status = "UP",
            Checks = new[]
            {
                new
                {
                    Name = "alive",
                    Status = "UP"
                }
            }
        });
    }
}
