using Fpl.Client.Models.Entries;

namespace Fpl.Client.Clients
{
    public interface IEntryClient
    {
        ValueTask<EntryEventPicks> GetEntryEventPicksAsync(int entryId, int eventId, CancellationToken cancellationToken = default);
        ValueTask<Entry> GetEntryAsync(int entryId, CancellationToken cancellationToken = default);
    }
}
