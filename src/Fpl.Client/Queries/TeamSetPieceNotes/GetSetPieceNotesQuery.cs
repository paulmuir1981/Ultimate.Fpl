using Fpl.Client.Models.TeamSetPieceNotes;

namespace Fpl.Client.Queries.TeamSetPieceNotes
{
    public class GetSetPieceNotesQuery : Query<SetPieceNotes>
    {
        public override string Uri => $"{base.Uri}team/set-piece-notes/";
    }
}
