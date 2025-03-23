using AutoMapper;
using DotaNerf.DTOs;
using DotaNerf.Models;

namespace DotaNerf.Mappings;

public class TeamMappings : Profile
{
    public TeamMappings()
    {
        CreateMap<Team, TeamDTO>();

        CreateMap<CreateTeamDTO, Team>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Players, opt => opt.Ignore()); 
    }
}
