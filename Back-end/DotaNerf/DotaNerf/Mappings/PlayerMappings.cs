using AutoMapper;
using DotaNerf.DTOs.PlayerDTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class PlayerMappings : Profile
{
	public PlayerMappings()
	{
        CreateMap<Player, PlayerDTO>()
            .ForMember(dest => dest.WinRate, opt => opt.MapFrom(src => src.Winrate))
            .ForMember(dest => dest.Games, opt => opt.MapFrom(src => src.Games));

        // Map from Player to PlayerDTO
        CreateMap<Player, PlayerDTO>()
            .ForMember(dest => dest.PlayerStats, opt => opt.MapFrom(src => src.PlayerStats));


        //CreateMap<CreatePlayerDTO, Player>()
        //    .ForMember(dest => dest.Id, opt => opt.Ignore())
        //    .ForMember(dest => dest.Winrate, opt => opt.Ignore()) 
        //    .ForMember(dest => dest.TotalGames, opt => opt.MapFrom(src => src.GamesWon + src.GamesLost));
    }
}
