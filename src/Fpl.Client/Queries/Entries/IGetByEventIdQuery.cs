namespace Fpl.Client.Queries.Entries
{
    public interface IGetByEventIdQuery<TResponse> : IQuery<TResponse>
    {
        int EventId { get; init; }
    }
}