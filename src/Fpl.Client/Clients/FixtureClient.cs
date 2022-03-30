using Fpl.Client.Models.Fixtures;
using Fpl.Client.Queries.Fixtures;
using Microsoft.Extensions.Logging;

namespace Fpl.Client.Clients
{
    public class FixtureClient : Client, IFixtureClient
    {
        public FixtureClient(HttpClient client, ILogger<FixtureClient> logger = null) : base(client, logger)
        {
        }

        public ValueTask<List<Fixture>> GetFixturesAsync(int? eventId = null, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetFixturesAsync)} invoked");

            var query = new GetFixturesQuery { EventId = eventId };
            query.Validate();

            return GetAsync(query, cancellationToken);
        }

        public ValueTask<List<Fixture>> GetFutureFixturesAsync(CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetFutureFixturesAsync)} invoked");

            var query = new GetFutureFixturesQuery();
            query.Validate();

            return GetAsync(query, cancellationToken);
        }
    }
}