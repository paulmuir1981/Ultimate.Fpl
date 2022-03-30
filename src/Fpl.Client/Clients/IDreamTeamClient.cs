using Fpl.Client.Models.DreamTeams;

namespace Fpl.Client.Clients
{
    public interface IDreamTeamClient
    {
        ValueTask<DreamTeam> GetDreamTeamAsync(int eventId, CancellationToken cancellationToken = default);
    }
}
