namespace Fpl.Client.Queries.Entries
{
    public abstract class GetByEntryIdQuery<TResponse> : Query<TResponse>, IGetByEntryIdQuery
    {
        public int EntryId { get; init; }
        public override string Uri => $"{base.Uri}entry/{EntryId}/";
    }
}