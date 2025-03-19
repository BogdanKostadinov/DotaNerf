using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class PlayerMappings : Profile
{
	public PlayerMappings()
	{
        CreateMap<Player, PlayerDTO>()
            .ForMember(dest => dest.WinRate, opt => opt.MapFrom(src => src.Winrate))
            .ForMember(dest => dest.Games, opt => opt.MapFrom(src => src.Games));

        CreateMap<PlayerCreateDTO, Player>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Winrate, opt => opt.Ignore()) 
            .ForMember(dest => dest.TotalGames, opt => opt.MapFrom(src => src.GamesWon + src.GamesLost));
    }
}
