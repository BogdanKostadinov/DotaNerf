using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class GameStatsMapping : Profile
{
    public GameStatsMapping()
    {
        CreateMap<GameStatsDTO, GameStats>();
        CreateMap<GameStats, GameStatsDTO>();

        CreateMap<GameStatsCreateDTO, GameStats>()
            .ForMember(dest => dest.PlayerId, opt => opt.Ignore())
            .AfterMap((src, dest) => dest.PlayerId = src.PlayerId);
        CreateMap<GameStats, GameStatsCreateDTO>();
    }
}
