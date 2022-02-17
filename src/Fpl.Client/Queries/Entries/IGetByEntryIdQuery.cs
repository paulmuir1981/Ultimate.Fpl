namespace Fpl.Client.Queries.Entries
{
    public interface IGetByEntryIdQuery<TResponse> : IQuery<TResponse>
    {
        int EntryId { get; init; }
    }
}