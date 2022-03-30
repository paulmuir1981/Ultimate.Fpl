using System.Text.Json.Serialization;

namespace Fpl.Client.Models.Leagues
{
    public abstract class PagedResults<TResult>
    {
        [JsonPropertyName("has_next")]
        public bool HasNext { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<TResult> Results { get; set; }
    }
}