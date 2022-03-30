using Fpl.Client.Models.TeamSetPieceNotes;
using Fpl.Client.Queries.TeamSetPieceNotes;
using Microsoft.Extensions.Logging;

namespace Fpl.Client.Clients
{
    public class TeamSetPieceNotesClient : Client, ITeamSetPieceNotesClient
    {
        public TeamSetPieceNotesClient(HttpClient client, ILogger<TeamSetPieceNotesClient> logger = null) : base(client, logger)
        {
        }

        public ValueTask<SetPieceNotes> GetSetPieceNotesAsync(CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetSetPieceNotesAsync)} invoked");
            var query = new GetSetPieceNotesQuery();
            return GetAsync(query, cancellationToken);
        }
    }
}
