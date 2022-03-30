using System.ComponentModel.DataAnnotations;

namespace Fpl.Client.Queries.Fixtures
{
    public class GetFixturesQuery : GetFixturesBaseQuery
    {
        [Range(1, 38)]
        public int? EventId { get ; init; }
        public override string Uri => $"{base.Uri}{(EventId.HasValue ? $"?event={EventId}" : string.Empty)}";
    }
}