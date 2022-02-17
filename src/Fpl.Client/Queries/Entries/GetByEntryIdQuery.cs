namespace Fpl.Client.Queries.Entries
{
    public abstract class GetByEntryIdQuery<TResponse> : Query<TResponse>, IGetByEntryIdQuery<TResponse>
    {
        public int EntryId { get; init; }
        public override string RequestUri => $"{base.RequestUri}entry/{EntryId}/";
    }
}