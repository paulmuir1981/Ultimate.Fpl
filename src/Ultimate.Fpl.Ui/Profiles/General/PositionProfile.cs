using AutoMapper;
using Fpl.Client.Models.General;
using Ultimate.Fpl.Ui.Models.General;

namespace Ultimate.Fpl.Ui.Profiles.General
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