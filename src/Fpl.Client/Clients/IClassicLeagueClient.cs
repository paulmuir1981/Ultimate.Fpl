using Fpl.Client.Models.Leagues.Classic;

namespace Fpl.Client.Clients
{
    public interface IClassicLeagueClient
    {
        ValueTask<ClassicLeague> GetClassicLeagueAsync(int leagueId, int standingsPage = 1, int newEntriesPage = 1, CancellationToken cancellationToken = default);
    }
}
