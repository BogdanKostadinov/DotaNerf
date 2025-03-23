using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class PlayerStatsMapping : Profile
{
    public PlayerStatsMapping()
    {
        // Map PlayerStats -> PlayerStatsDTO
        CreateMap<PlayerStats, PlayerStatsDTO>()
            .ForMember(dest => dest.HeroPlayed, opt => opt.MapFrom(src => src.HeroPlayed));

        // Map PlayerStatsDTO -> PlayerStats
        CreateMap<PlayerStatsDTO, PlayerStats>()
            .ForMember(dest => dest.HeroPlayed, opt => opt.MapFrom(src => src.HeroPlayed))
            .ForMember(dest => dest.Game, opt => opt.Ignore())
            .ForMember(dest => dest.Player, opt => opt.Ignore()); 

        // Map CreatePlayerStatsDTO -> PlayerStats
        CreateMap<CreatePlayerStatsDTO, PlayerStats>()
            .ForMember(dest => dest.HeroPlayed, opt => opt.MapFrom(src => src.HeroPlayed))
            .ForMember(dest => dest.Game, opt => opt.Ignore()) 
            .ForMember(dest => dest.Player, opt => opt.Ignore()) 
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        // Map PlayerStats -> CreatePlayerStatsDTO
        CreateMap<PlayerStats, CreatePlayerStatsDTO>()
            .ForMember(dest => dest.HeroPlayed, opt => opt.MapFrom(src => src.HeroPlayed))
            .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId ?? Guid.Empty))
            .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId ?? Guid.Empty));
    }
}
