namespace Fpl.Client.Queries
{
    public abstract class Query<TResponse> : IQuery<TResponse>
    {
        private const string BaseUri = "https://fantasy.premierleague.com/api/";
        public virtual string RequestUri => BaseUri;
    }
}
