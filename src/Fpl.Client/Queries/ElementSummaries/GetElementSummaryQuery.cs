using Fpl.Client.Models.ElementSummaries;
using System.ComponentModel.DataAnnotations;

namespace Fpl.Client.Queries.ElementSummaries
{
    public class GetElementSummaryQuery : Query<ElementSummary>
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? ElementId { get; set; }
        public override string Uri => $"{base.Uri}element-summary/{ElementId}/";
    }
}
