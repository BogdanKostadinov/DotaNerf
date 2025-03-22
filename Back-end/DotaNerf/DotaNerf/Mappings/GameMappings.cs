using AutoMapper;
using DotaNerf.DTOs.GameDTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class GameMappings : Profile
{
    public GameMappings()
    {
        CreateMap<Game, GameDTO>()
            .ForMember(dest => dest.PlayerStats, opt => opt.MapFrom(src => src.PlayerStats));
        CreateMap<CreateGameDTO, Game>();
    }
}
