using Fpl.Client.Models.General;

namespace Fpl.Client.Queries.General
{
    public class GetDataQuery : Query<Data>
    {
        public override string Uri => $"{base.Uri}bootstrap-static/";
    }
}