using Fpl.Client.Models.Leagues.Classic;

namespace Fpl.Client.Queries.Leagues.Classic
{
    public class GetClassicLeagueQuery : GetLeagueBaseQuery<ClassicLeague>
    {
        public override string LeagueType => "classic";
    }
}
