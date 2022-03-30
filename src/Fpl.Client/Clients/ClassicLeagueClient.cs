using Fpl.Client.Models.Leagues.Classic;
using Fpl.Client.Queries.Leagues.Classic;
using Microsoft.Extensions.Logging;

namespace Fpl.Client.Clients
{
    public class ClassicLeagueClient : LeagueClient, IClassicLeagueClient
    {
        public ClassicLeagueClient(HttpClient client, ILogger<ClassicLeagueClient> logger = null) : base(client, logger) { }

        public ValueTask<ClassicLeague> GetClassicLeagueAsync(int leagueId, int standingsPage = 1, int newEntriesPage = 1, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetClassicLeagueAsync)} invoked");
            var query = new GetClassicLeagueQuery { LeagueId = leagueId, StandingsPage = standingsPage, NewEntriesPage = newEntriesPage };
            return GetLeagueAsync(query, cancellationToken);
        }
    }
}