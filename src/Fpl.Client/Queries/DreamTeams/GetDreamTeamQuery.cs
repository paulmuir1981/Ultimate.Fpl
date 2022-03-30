using Fpl.Client.Models.DreamTeams;
using System.ComponentModel.DataAnnotations;

namespace Fpl.Client.Queries.DreamTeams
{
    public class GetDreamTeamQuery : Query<DreamTeam>
    {
        [Required]
        [Range(1, 38)]
        public int? EventId { get; init; }
        public override string Uri => $"{base.Uri}dream-team/{EventId}/";
    }
}
