using System.ComponentModel.DataAnnotations;

namespace Fpl.Client.Queries.Leagues
{
    public abstract class GetLeagueBaseQuery<TLeague> : Query<TLeague>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? LeagueId { get; init; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? StandingsPage { get; init; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? NewEntriesPage { get; init; }
        public abstract string LeagueType { get; }
        public override string Uri => $"{base.Uri}leagues-{LeagueType}/{LeagueId}/standings?page_new_entries={NewEntriesPage}&page_standings={StandingsPage}";
    }
}
