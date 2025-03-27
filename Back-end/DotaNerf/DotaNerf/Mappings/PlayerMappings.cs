using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class PlayerMappings : Profile
{
	public PlayerMappings()
	{
        CreateMap<CreatePlayerDTO, Player>();

        CreateMap<PlayerDTO, Player>()
            .ForMember(dest => dest.PlayerDetails,
                opt => opt.MapFrom(src => src.PlayerDetails))
            .ForMember(dest => dest.PlayerStats,
                opt => opt.MapFrom(src => src.PlayerStats));
        CreateMap<Player, PlayerDTO>()
            .ForMember(dest => dest.PlayerDetails, opt => opt.MapFrom(src => src.PlayerDetails))
            .ForMember(dest => dest.PlayerStats, opt =>
                opt.MapFrom((src, dest, destMember, context) =>
                    src.PlayerStats.Where(ps => ps.GameId == (Guid)context.Items["GameId"])));
    }
}
