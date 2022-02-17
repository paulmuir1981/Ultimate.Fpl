namespace Fpl.Client.Queries
{
    public interface IQuery<out TResponse> : IQuery { }

    public interface IQuery
    {
        string RequestUri { get; }
    }
}
