using AutoMapper;
using DotaNerf.DTOs.PlayerStatsDTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class PlayerStatsMapping : Profile
{
    public PlayerStatsMapping()
    {
        CreateMap<PlayerStatsDTO, PlayerStats>();
        CreateMap<PlayerStats, PlayerStatsDTO>();

        CreateMap<CreatePlayerStatsDTO, PlayerStats>()
            .ForMember(dest => dest.PlayerId, opt => opt.Ignore())
            .AfterMap((src, dest) => dest.PlayerId = src.PlayerId);
        CreateMap<PlayerStats, CreatePlayerStatsDTO>();
    }
}
