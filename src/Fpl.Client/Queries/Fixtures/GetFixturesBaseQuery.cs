using Fpl.Client.Models.Fixtures;

namespace Fpl.Client.Queries.Fixtures
{
    public abstract class GetFixturesBaseQuery : Query<List<Fixture>>
    {
        public override string Uri => $"{base.Uri}fixtures";
    }
}