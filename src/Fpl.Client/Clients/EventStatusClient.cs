using Fpl.Client.Models.EventStatus;
using Fpl.Client.Queries.EventStatus;
using Microsoft.Extensions.Logging;

namespace Fpl.Client.Clients
{
    public class EventStatusClient : Client, IEventStatusClient
    {
        public EventStatusClient(HttpClient client, ILogger<EventStatusClient> logger = null) : base(client, logger)
        {
        }

        public ValueTask<EventStatus> GetEventStatusAsync(CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetEventStatusAsync)} invoked");
            return GetAsync(new GetEventStatusQuery(), cancellationToken);
        }
    }
}
