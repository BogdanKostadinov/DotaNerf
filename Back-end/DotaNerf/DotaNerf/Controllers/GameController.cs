using AutoMapper;
using DotaNerf.Data;
using DotaNerf.DTOs;
using DotaNerf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotaNerf.Controllers;

[ApiController]
[Route("/games")]
public class GameController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public GameController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetGamesAsync()
    {
        var games = await _context.Games
            .Include(g => g.PlayerStats)
            .ThenInclude(ps => ps.HeroPlayed)
            .ToListAsync();

        var gameDtos = _mapper.Map<List<GameDTO>>(games);

        if (!games.Any())
        {
            return NotFound("No games found in the database.");
        }

        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGameAsync(Guid id)
    {
        var game = await _context.Games
            .Include(g => g.PlayerStats)
            .ThenInclude(ps => ps.HeroPlayed)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (game == null)
        {
            return NotFound();
        }

        var gameDto = _mapper.Map<GameDTO>(game);
        return Ok(gameDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] CreateGameDTO createGameDto)
    {
        if (createGameDto == null)
        {
            return BadRequest("Game data is required.");
        }

        var game = _mapper.Map<Game>(createGameDto);

        // Create new teams
        game.RadiantTeam = new Team { Name = createGameDto.RadiantTeam.Name };
        game.DireTeam = new Team { Name = createGameDto.DireTeam.Name };

        // Associate existing players with the new teams
        foreach (var playerId in createGameDto.RadiantTeam.PlayerIds)
        {
            var player = await _context.Players.FindAsync(playerId);
            if (player != null)
            {
                player.Teams.Add(game.RadiantTeam);
                game.RadiantTeam.Players.Add(player);
            }
        }

        foreach (var playerId in createGameDto.DireTeam.PlayerIds)
        {
            var player = await _context.Players.FindAsync(playerId);
            if (player != null)
            {
                player.Teams.Add(game.DireTeam);
                game.DireTeam.Players.Add(player);
            }
        }

        // Add the game to the context and save changes
        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        if (game == null)
        {
            return StatusCode(500, "An error occurred while creating the game.");
        }

        var gameDto = _mapper.Map<GameDTO>(game);
        return CreatedAtAction(nameof(GetGameAsync), new { id = game.Id }, gameDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGameAsync(Guid id)
    {
        var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
        if (game == null)
        {
            return NotFound($"No game found in the database with id: {id}");
        }

        // First, delete all player stats related to this game
        var relatedStats = await _context.PlayerStats.Where(ps => ps.GameId == id).ToListAsync();
        _context.PlayerStats.RemoveRange(relatedStats);

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}