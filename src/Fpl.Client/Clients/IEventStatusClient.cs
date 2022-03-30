using Fpl.Client.Models.EventStatus;

namespace Fpl.Client.Clients
{
    public interface IEventStatusClient
    {
        ValueTask<EventStatus> GetEventStatusAsync(CancellationToken cancellationToken = default);
    }
}
