using DotaNerf.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotaNerf.Controllers;

[ApiController]
[Route("/heroes")]
public class HeroController : ControllerBase
{
    private readonly DataContext _context;

    public HeroController(DataContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetHeroes")]
    public async Task<IActionResult> GetHeroesAsync()
    {
        var heroes = await _context.Heroes.ToListAsync();
        if (!heroes.Any())
        {
            return NotFound("No heroes found in the database.");
        }
        return Ok(heroes);
    }

    [HttpGet("{id}", Name = "GetHero")]
    public async Task<IActionResult> GetHeroAsync(int id)
    {
        var hero = await _context.Heroes
            .FirstOrDefaultAsync(m => m.Id == id);

        if (hero is null)
        {
            return NotFound($"No hero found in the database with id: {id}");
        }

        return Ok(hero);
    }
}
