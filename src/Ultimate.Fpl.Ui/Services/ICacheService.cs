using Ultimate.Fpl.Ui.Models.General;
using Ultimate.Fpl.Ui.Models.Entries;

namespace Ultimate.Fpl.Ui.Services
{
    public interface ICacheService
    {
        Task<Data> GetDataAsync(CancellationToken cancellationToken = default);
        Task SetDataAsync(Data data, CancellationToken cancellationToken = default);
        Task<EntryEventPicks> GetEntryEventPicksAsync(int entryId, int eventId, CancellationToken cancellationToken = default);
        Task<Entry> GetEntryAsync(int entryId, CancellationToken cancellationToken = default);
        Task SetEntryEventPicksAsync(int entryId, int eventId, EntryEventPicks team, CancellationToken cancellationToken = default);
        Task SetEntryAsync(int entryId, Entry team, CancellationToken cancellationToken = default);
    }
}