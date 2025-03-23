using DotaNerf.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotaNerf.Controllers;

[ApiController]
[Route("/teams")]
public class TeamController : ControllerBase
{
    private readonly DataContext _context;

    public TeamController(DataContext dataContext)
    {
        _context = dataContext;
    }

    [HttpGet(Name = "GetTeams")]
    public async Task<IActionResult> GetTeamsAsync()
    {
        var teams = await _context.Teams.ToListAsync();

        return Ok(teams);
    }
}
