using AutoMapper;
using ClientPick = Fpl.Client.Models.Entries.Pick;
using Ultimate.Fpl.Ui.Models.Entries;
using Ultimate.Fpl.Ui.Models.General;

namespace Ultimate.Fpl.Ui.Profiles.Entries
{
    public class PickProfile : Profile
    {
        public PickProfile()
        {
            //Source -> Destination
            CreateMap<ClientPick, Pick>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Element))
                .ForMember(
                    dest => dest.Ordinal,
                    opt => opt.MapFrom(src => src.Position));
            CreateMap<Player, Pick>();
        }
    }
}
