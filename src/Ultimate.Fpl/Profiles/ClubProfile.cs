using System.Collections.Generic;
using System.Linq;
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

            CreateMap<IEnumerable<Player>, Club>()
                .ForMember(
                    dest => dest.PenaltyTakers,
                    opt => opt.MapFrom(src => src
                        .Where(x => x.PenaltiesOrder.HasValue)
                        .OrderBy(x => x.PenaltiesOrder)
                        .ToList()))
                .ForMember(
                    dest => dest.CornersAndIndirectFreekickTakers,
                    opt => opt.MapFrom(src => src
                        .Where(x => x.CornersAndIndirectFreekicksOrder.HasValue)
                        .OrderBy(x => x.CornersAndIndirectFreekicksOrder)
                        .ToList()))
                .ForMember(
                    dest => dest.DirectFreekickTakers,
                    opt => opt.MapFrom(src => src
                        .Where(x => x.DirectFreekicksOrder.HasValue)
                        .OrderBy(x => x.DirectFreekicksOrder)
                        .ToList()));
        }
    }

}