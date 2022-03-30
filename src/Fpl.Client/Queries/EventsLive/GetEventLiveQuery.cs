using Fpl.Client.Models.EventsLive;
using System.ComponentModel.DataAnnotations;

namespace Fpl.Client.Queries.EventsLive
{
    public class GetEventLiveQuery : Query<EventLive>
    {
        [Required]
        [Range(1, 38)]
        public int? EventId { get; init; }
        public override string Uri => $"{base.Uri}event/{EventId}/live/";
    }
}
