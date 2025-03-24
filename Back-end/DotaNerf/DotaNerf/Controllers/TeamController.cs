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
        var teams = await _context.Teams
            .Include(t => t.Players)
            .ToListAsync();

        return Ok(teams);
    }

    [HttpGet("{id}", Name = "GetTeam")]
    public async Task<IActionResult> GetTeamAsync(Guid id)
    {
        var team = await _context.Teams
            .Include(t => t.Players)
            .FirstOrDefaultAsync(team => team.Id == id);

        if (team is null)
        {
            return NotFound();
        }

        return Ok(team);
    }
}
