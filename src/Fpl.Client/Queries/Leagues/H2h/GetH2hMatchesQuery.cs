using Fpl.Client.Models.Leagues.H2h;
using System.ComponentModel.DataAnnotations;

namespace Fpl.Client.Queries.Leagues.H2h
{
    public class GetH2hMatchesQuery : Query<Matches>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? LeagueId { get; init; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? Page { get; init; }

        [Range(1, 38)]
        public int? EventId { get; init; }
        public override string Uri => $"{base.Uri}leagues-h2h-matches/league/{LeagueId}?page={Page}{(EventId.HasValue ? $"&event={EventId}" : string.Empty)}";
    }
}
