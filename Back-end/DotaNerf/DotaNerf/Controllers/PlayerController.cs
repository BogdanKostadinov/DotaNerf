using DotaNerf.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotaNerf.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(ILogger<PlayerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<Player>> Get()
    {
        var players = await Task.FromResult(new List<Player>());
        return players;
    }
}
