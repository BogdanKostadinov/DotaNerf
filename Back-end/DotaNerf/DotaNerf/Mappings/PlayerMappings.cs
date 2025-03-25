using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class PlayerMappings : Profile
{
	public PlayerMappings()
	{
        CreateMap<CreatePlayerDTO, Player>();
        //CreateMap<Player, PlayerDTO>();
        
        CreateMap<Player, PlayerDTO>()
            .ForMember(dest => dest.PlayerStats, opt =>
                opt.MapFrom((src, dest, destMember, context) =>
                    src.PlayerStats.Where(ps => ps.GameId == (Guid)context.Items["GameId"])));
    }
}
