namespace Fpl.Client.Queries.EventStatus
{
    public class GetEventStatusQuery : Query<Models.EventStatus.EventStatus>
    {
        public override string Uri => $"{base.Uri}event-status/";
    }
}
