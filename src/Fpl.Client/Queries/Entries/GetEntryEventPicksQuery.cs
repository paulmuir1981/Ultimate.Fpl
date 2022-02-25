using Fpl.Client.Models.Entries;

namespace Fpl.Client.Queries.Entries
{
    public class GetEntryEventPicksQuery : GetByEntryIdQuery<EntryEventPicks>, IGetByEventIdQuery
    {
        public int EventId { get; init; }
        public override string Uri => $"{base.Uri}event/{EventId}/picks/";
    }
}