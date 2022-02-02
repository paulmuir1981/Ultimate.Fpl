using AutoMapper;
using Fpl.Client.Models.Entries;
using Ultimate.Fpl.Ui.Models.Entries;
using static Fpl.Client.Models.Constants;
using ClientEntryEventPicks = Fpl.Client.Models.Entries.EntryEventPicks;
using EntryEventPicks = Ultimate.Fpl.Ui.Models.Entries.EntryEventPicks;

namespace Ultimate.Fpl.Ui.Profiles.Entries
{
    public class EntryEventPicksProfile : Profile
    {
        private readonly Dictionary<string, Chip> _ChipMap;
        public EntryEventPicksProfile()
        {
            _ChipMap = new Dictionary<string, Chip>()
            {
                { Chips.Wildcard, Chip.Wildcard },
                { Chips.BenchBoost, Chip.BenchBoost },
                { Chips.TripleCaptain, Chip.TripleCaptain },
                { Chips.FreeHit, Chip.FreeHit }
            };

            //Source -> Destination
            CreateMap<ClientEntryEventPicks, EntryEventPicks>()
                .ForMember(
                    dest => dest.ActiveChip,
                    opt => opt.MapFrom(src => MapChip(src.ActiveChip)));

            CreateMap<EntryHistory, EntryEventPicks>()
                .ForMember(
                    dest => dest.EventId,
                    opt => opt.MapFrom(src => src.Event))
                .ForMember(
                    dest => dest.Points,
                    opt => opt.MapFrom(src => src.Points))
                .ForMember(
                    dest => dest.TotalPoints,
                    opt => opt.MapFrom(src => src.TotalPoints))
                .ForMember(
                    dest => dest.Rank,
                    opt => opt.MapFrom(src => src.Rank))
                .ForMember(
                    dest => dest.OverallRank,
                    opt => opt.MapFrom(src => src.OverallRank))
                .ForMember(
                    dest => dest.Bank,
                    opt => opt.MapFrom(src => src.Bank / 10.0M))
                .ForMember(
                    dest => dest.Value,
                    opt => opt.MapFrom(src => src.Value / 10.0M))
                .ForMember(
                    dest => dest.TransferCount,
                    opt => opt.MapFrom(src => src.EventTransfers))
                .ForMember(
                    dest => dest.TransferCost,
                    opt => opt.MapFrom(src => src.EventTransfersCost))
                .ForMember(
                    dest => dest.PointsOnBench,
                    opt => opt.MapFrom(src => src.PointsOnBench));
        }

        private Chip MapChip(string activeChip)
        {
            return string.IsNullOrEmpty(activeChip) ? Chip.None : 
                _ChipMap.TryGetValue(activeChip, out var chip) ? chip : Chip.None;
        }
    }
}
