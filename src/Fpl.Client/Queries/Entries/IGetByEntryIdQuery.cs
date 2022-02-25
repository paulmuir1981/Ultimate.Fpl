namespace Fpl.Client.Queries.Entries
{
    public interface IGetByEntryIdQuery : IQuery
    {
        int EntryId { get; init; }
    }
}