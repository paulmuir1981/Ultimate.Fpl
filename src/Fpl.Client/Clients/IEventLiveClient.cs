using Fpl.Client.Models.EventsLive;

namespace Fpl.Client.Clients
{
    public interface IEventLiveClient
    {
        ValueTask<EventLive> GetEventLiveAsync(int eventId, CancellationToken cancellationToken = default);
    }
}
