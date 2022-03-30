using Fpl.Client.Models.Leagues.H2h;

namespace Fpl.Client.Clients
{
    public interface IH2hLeagueClient
    {
        ValueTask<H2hLeague> GetH2hLeagueAsync(int leagueId, int standingsPage = 1, int newEntriesPage = 1, CancellationToken cancellationToken = default);
        ValueTask<Matches> GetH2hMatchesAsync(int leagueId, int page = 1, int? eventId = null, CancellationToken cancellationToken = default);
    }
}
