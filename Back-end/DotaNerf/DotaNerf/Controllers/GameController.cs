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
            .Include(g => g.RadiantTeam)
            .ThenInclude(t => t!.Players)
            .ThenInclude(p => p.PlayerStats)
            .ThenInclude(ps => ps.HeroPlayed)
            .Include(g => g.DireTeam)
            .ThenInclude(t => t!.Players)
            .ThenInclude(p => p.PlayerStats)
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
        // Validate the incoming data
        if (createGameDto == null)
        {
            return BadRequest("Request data is null");
        }

        if (createGameDto.RadiantTeam == null || createGameDto.DireTeam == null)
        {
            return BadRequest("Both RadiantTeam and DireTeam are required");
        }

        if (!createGameDto.RadiantTeam.Players.Any() || !createGameDto.DireTeam.Players.Any())
        {
            return BadRequest("Both teams must have players");
        }

        // Create a new game entity
        var newGame = new Game
        {
            WinningTeam = createGameDto.WinningTeam,
            RadiantTeam = new Team
            {
                Id = Guid.NewGuid(),
                Name = createGameDto.RadiantTeam.Name,
                Players = new List<Player>()
            },
            DireTeam = new Team
            {
                Id = Guid.NewGuid(),
                Name = createGameDto.DireTeam.Name,
                Players = new List<Player>()
            }
        };

        await _context.Games.AddAsync(newGame);
        await _context.SaveChangesAsync();

        // Process RadiantTeam players
        foreach (var playerDto in createGameDto.RadiantTeam.Players)
        {
            var existingPlayer = await _context.Players
                .Include(p => p.PlayerStats)
                .FirstOrDefaultAsync(p => p.Id == playerDto.Id);

            if (existingPlayer != null)
            {
                // Append new PlayerStats to the existing player
                existingPlayer.PlayerStats.Add(new PlayerStats
                {
                    GameId = newGame.Id,
                    TeamId = newGame.RadiantTeam.Id,
                    HeroPlayed = new Hero { Name = playerDto.PlayerStats.HeroPlayed.Name },
                    Kills = playerDto.PlayerStats.Kills,
                    Deaths = playerDto.PlayerStats.Deaths,
                    Assists = playerDto.PlayerStats.Assists
                });

                newGame.RadiantTeam.Players.Add(existingPlayer); // Add existing player to the new team's list
            }
            else
            {
                return BadRequest($"Player with ID {playerDto.Id} not found in RadiantTeam.");
            }
        }

        // Process DireTeam players
        foreach (var playerDto in createGameDto.DireTeam.Players)
        {
            var existingPlayer = await _context.Players
                .Include(p => p.PlayerStats)
                .FirstOrDefaultAsync(p => p.Id == playerDto.Id);

            if (existingPlayer != null)
            {
                // Append new PlayerStats to the existing player
                existingPlayer.PlayerStats.Add(new PlayerStats
                {
                    GameId = newGame.Id,
                    TeamId = newGame.DireTeam.Id,
                    HeroPlayed = new Hero { Name = playerDto.PlayerStats.HeroPlayed.Name },
                    Kills = playerDto.PlayerStats.Kills,
                    Deaths = playerDto.PlayerStats.Deaths,
                    Assists = playerDto.PlayerStats.Assists
                });

                newGame.DireTeam.Players.Add(existingPlayer); // Add existing player to the new team's list
            }
            else
            {
                return BadRequest($"Player with ID {playerDto.Id} not found in DireTeam.");
            }
        }

        await _context.SaveChangesAsync();

        // Return a success response
        return Ok(new { Message = "Game created successfully", GameId = Guid.NewGuid() });
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

    public static PlayerStats AddNewStatsForPlayer(Guid playerId) {

        //find hero
        return new PlayerStats
        {
            PlayerId = playerId,
            HeroPlayed = new Hero { Name = "New Hero" },
            Kills = 0,
            Deaths = 0,
            Assists = 0
        };
    }
}

