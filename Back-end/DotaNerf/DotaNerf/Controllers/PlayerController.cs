using AutoMapper;
using DotaNerf.Data;
using DotaNerf.DTOs;
using DotaNerf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotaNerf.Controllers;

[ApiController]
[Route("/players")]
public class PlayerController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PlayerController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetPlayers")]
    public async Task<IActionResult> GetPlayersAsync()
    {
        var players = await _context.Players
            //.Include(p => p.Games)
            .Include(p => p.PlayerStats)
            .ToListAsync();

        return Ok(players);
    }


    [HttpGet("{id}", Name = "GetPlayer")]
    public async Task<IActionResult> GetPlayerAsync(Guid id)
    {
        var player = await _context.Players
            //.Include(m => m.Games)
            .AsTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (player is null)
        {
            return NotFound();
        }

        return Ok(player);
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> AddGameForPlayerAsync(Guid id, [FromBody] CreatePlayerStatsDTO gameStatsDTO)
    //{
    //    // Find the player by ID
    //    var player = await _context.Players
    //        .Include(p => p.Games)
    //        .AsTracking()
    //        .FirstOrDefaultAsync(p => p.Id == id);

    //    if (player is null)
    //    {
    //        return NotFound("Player not found.");
    //    }

    //    // Map DTO to GameStats entity
    //    var gameStats = _mapper.Map<PlayerStats>(gameStatsDTO);
    //    gameStats.Id = Guid.NewGuid();
    //    gameStats.PlayerId = id;

    //    // Check if the Hero exists
    //    var hero = await _context.Heroes.FirstOrDefaultAsync(h => h.Name == gameStatsDTO.HeroPlayed.Name);
    //    if (hero == null)
    //    {
    //        hero = new Hero { Name = gameStatsDTO.HeroPlayed.Name };
    //        _context.Heroes.Add(hero);
    //    }
    //    gameStats.HeroPlayed = hero;

    //    //UpdatePlayerWithGame(player, gameStats);

    //    _context.PlayerStats.Add(gameStats);
    //    _context.Entry(player).State = EntityState.Modified;

    //    await _context.SaveChangesAsync();

    //    return CreatedAtRoute("GetPlayer", new { id = player.Id }, player);
    //}

}
