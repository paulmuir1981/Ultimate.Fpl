using Fpl.Client.Models.EntryHistory;

namespace Fpl.Client.Queries.Entries
{
    public class GetEntryHistoryQuery : GetByEntryIdQuery<EntryHistory> 
    {
        public override string Uri => $"{base.Uri}history/";
    }
}