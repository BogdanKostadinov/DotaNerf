using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class GameMappings : Profile
{
    public GameMappings()
    {
        CreateMap<Game, GameDTO>();
        CreateMap<GameDTO, Game>()
            .ForMember(dest => dest.RadiantTeam, opt => opt.Ignore()) 
            .ForMember(dest => dest.DireTeam, opt => opt.Ignore())   
            .ForMember(dest => dest.Players, opt => opt.Ignore());  

        // Map CreateGameDTO -> Game
        CreateMap<CreateGameDTO, Game>()
            .ForMember(dest => dest.RadiantTeam, opt => opt.MapFrom(src => src.RadiantTeam))
            .ForMember(dest => dest.DireTeam, opt => opt.MapFrom(src => src.DireTeam))
            .ForMember(dest => dest.Players, opt => opt.Ignore()) 
            .ForMember(dest => dest.Id, opt => opt.Ignore()); 

        // Map Game -> CreateGameDTO
        CreateMap<Game, CreateGameDTO>()
            .ForMember(dest => dest.RadiantTeam, opt => opt.MapFrom(src => src.RadiantTeam))
            .ForMember(dest => dest.DireTeam, opt => opt.MapFrom(src => src.DireTeam));


    }
}
