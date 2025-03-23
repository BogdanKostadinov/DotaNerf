using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class TeamMappings : Profile
{
    public TeamMappings()
    {
        // Map Team -> TeamDTO
        CreateMap<Team, TeamDTO>()
            .ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.Players));

        // Map TeamDTO -> Team
        CreateMap<TeamDTO, Team>()
            .ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.Players)); 

        // Map CreateTeamDTO -> Team
        CreateMap<CreateTeamDTO, Team>()
            .ForMember(dest => dest.Players, opt => opt.Ignore()) 
            .ForMember(dest => dest.Id, opt => opt.Ignore());    
    }
}
