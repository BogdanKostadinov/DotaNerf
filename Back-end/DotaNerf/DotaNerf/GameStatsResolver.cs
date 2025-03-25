using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf;

public class GameStatsResolver : IValueResolver<Player, PlayerDTO, List<PlayerStatsDTO>>
{
    private readonly IMapper _mapper;

    public GameStatsResolver(IMapper mapper)
    {
        _mapper = mapper;
    }

    public List<PlayerStatsDTO> Resolve(Player source, PlayerDTO destination, List<PlayerStatsDTO> destMember, ResolutionContext context)
    {
        var gameId = context.Items.ContainsKey("GameId")
            ? (Guid)context.Items["GameId"]
            : Guid.Empty;

        return source.PlayerStats
            .Where(ps => ps.GameId == gameId)
            .Select(ps => _mapper.Map<PlayerStatsDTO>(ps))
            .ToList();
    }
}
