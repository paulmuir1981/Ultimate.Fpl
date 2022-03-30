using Fpl.Client.Models.Entries;
using Fpl.Client.Models.EntryEventPicks;
using Fpl.Client.Models.EntryTransfers;
using EntryHistory = Fpl.Client.Models.EntryHistory.EntryHistory;

namespace Fpl.Client.Clients
{
    public interface IEntryClient
    {
        ValueTask<Entry> GetEntryAsync(int entryId, CancellationToken cancellationToken = default);
        ValueTask<EntryEventPicks> GetEntryEventPicksAsync(int entryId, int eventId, CancellationToken cancellationToken = default);
        ValueTask<EntryHistory> GetEntryHistoryAsync(int entryId, CancellationToken cancellationToken = default);
        ValueTask<List<EntryTransfer>> GetEntryTransfersAsync(int entryId, CancellationToken cancellationToken = default);
    }
}
