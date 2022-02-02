using AutoMapper;
using Ultimate.Fpl.Models;

namespace Ultimate.Fpl.Profiles
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            //Source -> Destination
            CreateMap<ElementType, Position>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.SingularName))
                .ForMember(
                    dest => dest.ShortName,
                    opt => opt.MapFrom(src => src.SingularNameShort));
        }
    }

}