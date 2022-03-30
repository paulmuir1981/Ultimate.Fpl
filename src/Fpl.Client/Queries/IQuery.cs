namespace Fpl.Client.Queries
{
    public interface IQuery<TResponse>
    {
        string Uri { get; }
        void Validate();
    }
}