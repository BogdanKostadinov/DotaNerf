using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class GameMappings : Profile
{
    public GameMappings()
    {
        CreateMap<CreateGameDTO, Game>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.RadiantTeam, opt => opt.MapFrom(src => src.RadiantTeam))
            .ForMember(dest => dest.DireTeam, opt => opt.MapFrom(src => src.DireTeam))
            .ForMember(dest => dest.PlayerStats, opt => opt.MapFrom(src => src.PlayerStats));

        CreateMap<Game, GameDTO>()
            .ForMember(dest => dest.RadiantTeamId, opt => opt.MapFrom(src => src.RadiantTeam!.Id))
            .ForMember(dest => dest.DireTeamId, opt => opt.MapFrom(src => src.DireTeam!.Id))
            .ForMember(dest => dest.PlayerStats, opt => opt.MapFrom(src => src.PlayerStats));
    }
}
