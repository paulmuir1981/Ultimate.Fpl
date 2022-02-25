namespace Fpl.Client.Queries
{
    public abstract class Query : IQuery
    {
        private const string UriBase = "https://fantasy.premierleague.com/api/";
        public virtual string Uri => UriBase;
    }
    public abstract class Query<TResponse> : Query, IQuery<TResponse> { }
}