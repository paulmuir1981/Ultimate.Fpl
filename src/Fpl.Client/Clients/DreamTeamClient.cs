using Fpl.Client.Models.DreamTeams;
using Fpl.Client.Queries.DreamTeams;
using Microsoft.Extensions.Logging;

namespace Fpl.Client.Clients
{
    public class DreamTeamClient : Client, IDreamTeamClient
    {
        public DreamTeamClient(HttpClient client, ILogger<DreamTeamClient> logger = null) : base(client, logger)
        {
        }

        public ValueTask<DreamTeam> GetDreamTeamAsync(int eventId, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetDreamTeamAsync)} invoked");
            var query = new GetDreamTeamQuery { EventId = eventId };
            query.Validate();
            return GetAsync(query, cancellationToken);
        }
    }
}
