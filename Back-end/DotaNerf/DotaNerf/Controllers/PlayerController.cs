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
            .Include(p => p.PlayerDetails)
            .Include(p => p.PlayerStats)
            .ToListAsync();

        return Ok(players);
    }


    [HttpGet("{id}", Name = "GetPlayer")]
    public async Task<IActionResult> GetPlayerAsync(Guid id)
    {
        var player = await _context.Players
            .Include(p => p.PlayerDetails)
            .Include(p => p.PlayerStats)
            .AsTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (player is null)
        {
            return NotFound();
        }

        return Ok(player);
    }
}
