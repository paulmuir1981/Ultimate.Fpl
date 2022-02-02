using Ultimate.Fpl.Ui.Models.Entries;

namespace Ultimate.Fpl.Ui.Services
{
    public interface IEntryService
    {
        string MyEntryPlayerName { get; }
        int MyEntryId { get; }
        bool IsMyEntrySet { get; }
        Task<bool> SetMyEntryAsync(int entryId, CancellationToken cancellationToken = default);
        void ClearMyEntry();
        Task<Entry> GetEntryAsync(int entryId, CancellationToken cancellationToken = default);
        Task<EntryEventPicks> GetEntryEventPicksAsync(int entryId, int eventId, CancellationToken cancellationToken = default);
        Task<EntryEventPicks> GetEntryCurrentEventPicksAsync(int entryId, CancellationToken cancellationToken = default);
        Task<Entry> GetMyEntryAsync(CancellationToken cancellationToken = default);
        Task<EntryEventPicks> GetMyEntryEventPicksAsync(int eventId, CancellationToken cancellationToken = default);
        Task<EntryEventPicks> GetMyEntryCurrentEventPicksAsync(CancellationToken cancellationToken = default);
    }
}