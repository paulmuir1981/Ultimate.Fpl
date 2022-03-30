using Fpl.Client.Models.Leagues.H2h;

namespace Fpl.Client.Queries.Leagues.H2h
{
    public class GetH2hLeagueQuery : GetLeagueBaseQuery<H2hLeague>
    {
        public override string LeagueType => "h2h";
    }
}
