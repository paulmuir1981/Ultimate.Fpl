namespace Fpl.Client.Queries
{
    public interface IQuery
    {
        string Uri { get; }
    }
    public interface IQuery<TResponse> : IQuery { }
}
