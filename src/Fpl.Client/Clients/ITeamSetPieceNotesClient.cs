using Fpl.Client.Models.TeamSetPieceNotes;

namespace Fpl.Client.Clients
{
    public interface ITeamSetPieceNotesClient
    {
        ValueTask<SetPieceNotes> GetSetPieceNotesAsync(CancellationToken cancellationToken = default);
    }
}
