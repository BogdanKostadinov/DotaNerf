using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class PlayerMappings : Profile
{
	public PlayerMappings()
	{
        CreateMap<Player, PlayerDTO>()
             .ForMember(dest => dest.PlayerStats, opt => opt.MapFrom(src => src.PlayerStats.FirstOrDefault())); 

        CreateMap<PlayerDTO, Player>()
            .ForMember(dest => dest.PlayerStats, opt => opt.Ignore()) 
            .ForMember(dest => dest.Games, opt => opt.Ignore());
    }
}
