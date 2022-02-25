namespace Fpl.Client.Queries.Entries
{
    public interface IGetByEventIdQuery : IQuery
    {
        int EventId { get; init; }
    }
}