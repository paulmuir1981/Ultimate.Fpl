namespace Fpl.Client.Queries.Fixtures
{
    public class GetFutureFixturesQuery : GetFixturesBaseQuery
    {
        public override string Uri => $"{base.Uri}?future=1";
    }
}