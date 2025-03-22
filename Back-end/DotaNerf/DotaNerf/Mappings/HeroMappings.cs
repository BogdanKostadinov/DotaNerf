using AutoMapper;
using DotaNerf.DTOs.HeroDTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class HeroMappings : Profile
{
    public HeroMappings()
    {
        CreateMap<HeroDTO, Hero>();
        CreateMap<Hero, HeroDTO>();
    }
}
