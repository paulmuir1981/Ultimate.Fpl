using Fpl.Client.Queries.Leagues;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Fpl.Client.Clients
{
    public abstract class LeagueClient : Client
    {
        public LeagueClient(HttpClient client, ILogger logger = null) : base(client, logger) { }
        protected async ValueTask<TLeague> GetLeagueAsync<TLeague>(GetLeagueBaseQuery<TLeague> query, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetLeagueAsync)} invoked");

            query.Validate();

            try
            {
                return await GetAsync(query, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var paramName = nameof(query.LeagueId);
                Exception exception = new ArgumentException($"{paramName} ({query.LeagueId}) does not exist", paramName, ex);
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
