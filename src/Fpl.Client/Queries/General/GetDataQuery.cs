using Fpl.Client.Models.General;

namespace Fpl.Client.Queries.General
{
    public class GetDataQuery : Query<Data>
    {
        public override string RequestUri => $"{base.RequestUri}bootstrap-static/";
    }
}