using Fpl.Client.Models.Leagues.H2h;
using Fpl.Client.Queries.Leagues.H2h;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Fpl.Client.Clients
{
    public class H2hLeagueClient : LeagueClient, IH2hLeagueClient
    {
        public H2hLeagueClient(HttpClient client, ILogger<H2hLeagueClient> logger = null) : base(client, logger) { }

        public ValueTask<H2hLeague> GetH2hLeagueAsync(int leagueId, int standingsPage = 1, int newEntriesPage = 1, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetH2hLeagueAsync)} invoked");
            var query = new GetH2hLeagueQuery { LeagueId = leagueId, StandingsPage = standingsPage, NewEntriesPage = newEntriesPage };
            return GetLeagueAsync(query, cancellationToken);
        }

        public async ValueTask<Matches> GetH2hMatchesAsync(int leagueId, int page = 1, int? eventId = null, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetH2hMatchesAsync)} invoked");
            var query = new GetH2hMatchesQuery { LeagueId = leagueId, Page = page, EventId = eventId };
            query.Validate();

            try
            {
                return await GetAsync(query, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var paramName = nameof(leagueId);
                Exception exception = new ArgumentException($"{paramName} ({leagueId}) does not exist", paramName, ex);
                if (ex.StatusCode != HttpStatusCode.NotFound)
                {
                    exception = ex;
                }
                _logger?.LogError(exception, "{message}", exception.Message);
                throw exception;
            }
        }
    }
}