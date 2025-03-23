using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class PlayerMappings : Profile
{
	public PlayerMappings()
	{
        CreateMap<CreatePlayerDTO, Player>();
    }
}
