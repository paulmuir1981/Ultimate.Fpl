using Fpl.Client.Models.Fixtures;

namespace Fpl.Client.Clients
{
    public interface IFixtureClient
    {
        ValueTask<List<Fixture>> GetFixturesAsync(int? eventId = null, CancellationToken cancellationToken = default);
        ValueTask<List<Fixture>> GetFutureFixturesAsync(CancellationToken cancellationToken = default);
    }
}
