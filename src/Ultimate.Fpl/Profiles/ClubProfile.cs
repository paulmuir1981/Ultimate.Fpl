using AutoMapper;
using Fpl.Client.Models;
using Ultimate.Fpl.Models;

namespace Ultimate.Fpl.Profiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            //Source -> Destination
            CreateMap<Team, Club>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.ShortName,
                    opt => opt.MapFrom(src => src.ShortName));
        }
    }

}