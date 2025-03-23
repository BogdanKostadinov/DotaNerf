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
                .ThenInclude(rt => rt.Players)
                    .ThenInclude(p => p.PlayerStats)
            .Include(g => g.DireTeam)
                .ThenInclude(dt => dt.Players)
                    .ThenInclude(p => p.PlayerStats)
            .Select(g => new GameDTO
            {
                Id = g.Id,
                WinningTeam = g.WinningTeam,
                RadiantTeam = new TeamDTO
                {
                    Id = g.RadiantTeam.Id,
                    Name = g.RadiantTeam.Name,
                    Players = g.RadiantTeam.Players.Select(p => new PlayerDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        PlayerStats = p.PlayerStats.Select(ps => new PlayerStatsDTO
                        {
                            Kills = ps.Kills,
                            Deaths = ps.Deaths,
                            Assists = ps.Assists,
                            HeroPlayed = ps.HeroPlayed,
                            TeamId = ps.TeamId ?? Guid.Empty
                        }).ToList()
                    }).ToList()
                },
                DireTeam = new TeamDTO
                {
                    Id = g.DireTeam.Id,
                    Name = g.DireTeam.Name,
                    Players = g.DireTeam.Players.Select(p => new PlayerDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        PlayerStats = p.PlayerStats.Select(ps => new PlayerStatsDTO
                        {
                            Kills = ps.Kills,
                            Deaths = ps.Deaths,
                            Assists = ps.Assists,
                            HeroPlayed = ps.HeroPlayed,
                            TeamId = ps.TeamId ?? Guid.Empty
                        }).ToList()
                    }).ToList()
                }
            })
            .ToListAsync();

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
            .FirstOrDefaultAsync(m => m.Id == id);
        if (game is null)
        {
            return NotFound($"No game found in the database with id: {id}");
        }
        return Ok(game);
    }


    //[HttpPost]
    //public async Task<IActionResult> CreateGame([FromBody] CreateGameDTO request)
    //{
    //    // Create Radiant Team
    //    var radiantTeam = new Team
    //    {
    //        Id = request.RadiantTeam.Id,
    //        Name = request.RadiantTeam.Name,
    //        Players = request.RadiantTeam.Players.Select(p =>
    //        {
    //            var playerStats = new PlayerStats
    //            {
    //                Id = Guid.NewGuid(),
    //                Kills = p.PlayerStats.Kills,
    //                Deaths = p.PlayerStats.Deaths,
    //                Assists = p.PlayerStats.Assists,
    //                PlayerId = p.Id,
    //                HeroPlayed = new Hero
    //                {
    //                    Id = p.PlayerStats.HeroPlayed.Id,
    //                    Name = p.PlayerStats.HeroPlayed.Name
    //                }
    //            };

    //            var player = new Player
    //            {
    //                Id = p.Id,
    //                Name = p.Name
    //            };

    //            // Add PlayerStats to Player
    //            player.PlayerStats.Add(playerStats);

    //            return player;
    //        }).ToList()
    //    };

    //    // Similar logic for Dire Team
    //    var direTeam = new Team
    //    {
    //        Id = request.DireTeam.Id,
    //        Name = request.DireTeam.Name,
    //        Players = request.DireTeam.Players.Select(p =>
    //        {
    //            var playerStats = new PlayerStats
    //            {
    //                Id = Guid.NewGuid(),
    //                Kills = p.PlayerStats.Kills,
    //                Deaths = p.PlayerStats.Deaths,
    //                Assists = p.PlayerStats.Assists,
    //                PlayerId = p.Id,
    //                HeroPlayed = new Hero
    //                {
    //                    Id = p.PlayerStats.HeroPlayed.Id,
    //                    Name = p.PlayerStats.HeroPlayed.Name
    //                }
    //            };

    //            var player = new Player
    //            {
    //                Id = p.Id,
    //                Name = p.Name
    //            };

    //            // Add PlayerStats to Player
    //            player.PlayerStats.Add(playerStats);

    //            return player;
    //        }).ToList()
    //    };

    //    // Create Game
    //    var game = new Game
    //    {
    //        Id = Guid.NewGuid(),
    //        RadiantTeam = radiantTeam,
    //        DireTeam = direTeam,
    //        RadiantTeamId = radiantTeam.Id,
    //        DireTeamId = direTeam.Id,
    //        WinningTeam = request.WinningTeam
    //    };



    //    // Save to Database
    //    _context.Games.Add(game);
    //    await _context.SaveChangesAsync();

    //    return CreatedAtAction(nameof(CreateGame), new { id = game.Id }, game);
    //}
}
