using Fpl.Client.Models.EntryTransfers;

namespace Fpl.Client.Queries.Entries
{
    public class GetEntryTransfersQuery : GetByEntryIdQuery<List<EntryTransfer>>
    {
        public override string Uri => $"{base.Uri}transfers/";
    }
}
