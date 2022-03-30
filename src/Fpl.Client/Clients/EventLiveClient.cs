using Fpl.Client.Models.EventsLive;
using Fpl.Client.Queries.EventsLive;
using Microsoft.Extensions.Logging;

namespace Fpl.Client.Clients
{
    public class EventLiveClient : Client, IEventLiveClient
    {
        public EventLiveClient(HttpClient client, ILogger<EventLiveClient> logger = null) : base(client, logger) { }

        public ValueTask<EventLive> GetEventLiveAsync(int eventId, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetEventLiveAsync)} invoked");
            var query = new GetEventLiveQuery { EventId = eventId };
            query.Validate();
            return GetAsync(query, cancellationToken);
        }
    }
}