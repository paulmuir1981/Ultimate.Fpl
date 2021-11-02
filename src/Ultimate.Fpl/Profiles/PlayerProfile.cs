using System;
using AutoMapper;
using Fpl.Client.Models;
using Ultimate.Fpl.Extensions;
using Ultimate.Fpl.Models;

namespace Ultimate.Fpl.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            //Source -> Destination
            CreateMap<Element, Player>()
                .ForMember(
                    dest => dest.ClubId,
                    opt => opt.MapFrom(src => src.Team))
                .ForMember(
                    dest => dest.Availability,
                    opt => opt.MapFrom(src => src.ChanceOfPlayingNextRound.GetValueOrDefault(100)))
                .ForMember(
                    dest => dest.PositionId,
                    opt => opt.MapFrom(src => src.ElementType))
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.NowCost / 10.0M))
                .ForMember(
                    dest => dest.ValueForm,
                    opt => opt.MapFrom(src => Math.Round(src.Form / (src.NowCost / 10.0M), 2)))
                .ForMember(
                    dest => dest.ValueSeason,
                    opt => opt.MapFrom(src => Math.Round(src.TotalPoints / (src.NowCost / 10.0M), 2)))
                .ForMember(
                    dest => dest.FirstNameDiacriticless,
                    opt => opt.MapFrom(src => src.FirstName == null ? null : src.FirstName.ToDiacriticless()))
                .ForMember(
                    dest => dest.SecondNameDiacriticless,
                    opt => opt.MapFrom(src => src.SecondName == null ? null : src.SecondName.ToDiacriticless()))
                .ForMember(
                    dest => dest.WebNameDiacriticless,
                    opt => opt.MapFrom(src => src.WebName == null ? null : src.WebName.ToDiacriticless()))
                .ForMember(
                    dest => dest.IctIndexValue,
                    opt => opt.MapFrom(src => Math.Round(src.IctIndex / (src.NowCost / 10.0M), 2)))
                .ForMember(
                    dest => dest.PointsPerMinute,
                    opt => opt.MapFrom(src =>
                        src.Minutes == 0 ? 0 : Math.Round(src.TotalPoints / (decimal)src.Minutes, 2)))
                .ForMember(
                    dest => dest.PointsPerGameValue,
                    opt => opt.MapFrom(src =>
                        src.PointsPerGame == 0 ? 0 : Math.Round(src.PointsPerGame / (src.NowCost / 10.0M), 2)));

            CreateMap<Club, Player>()
                .ForMember(
                    dest => dest.Id, 
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.ClubName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.ClubShortName,
                    opt => opt.MapFrom(src => src.ShortName));

            CreateMap<Position, Player>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.PositionName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.PositionShortName,
                    opt => opt.MapFrom(src => src.ShortName));
        }
    }
}