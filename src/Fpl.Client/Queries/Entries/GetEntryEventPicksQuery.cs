using Fpl.Client.Models.Entries;

namespace Fpl.Client.Queries.Entries
{
    public class GetEntryEventPicksQuery : GetByEntryIdQuery<EntryEventPicks>, IGetByEventIdQuery<EntryEventPicks>
    {
        public int EventId { get; init; }
        public override string RequestUri => $"{base.RequestUri}event/{EventId}/picks/";
    }
}