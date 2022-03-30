using System.ComponentModel.DataAnnotations;

namespace Fpl.Client.Queries.Entries
{
    public abstract class GetByEntryIdQuery<TResponse> : Query<TResponse>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? EntryId { get; init; }
        public override string Uri => $"{base.Uri}entry/{EntryId}/";
    }
}