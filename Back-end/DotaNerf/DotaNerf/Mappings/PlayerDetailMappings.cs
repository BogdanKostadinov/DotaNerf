using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class PlayerDetailMappings : Profile
{
    public PlayerDetailMappings()
    {
        CreateMap<PlayerDetails, PlayerDetailsDTO>();
        CreateMap<PlayerDetailsDTO, PlayerDetails>();
    }
}
