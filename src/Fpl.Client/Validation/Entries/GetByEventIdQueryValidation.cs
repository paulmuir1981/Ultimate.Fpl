using Fpl.Client.Queries.Entries;

namespace Fpl.Client.Validation.Entries
{
    public class GetByEventIdQueryValidation : Validation<IGetByEventIdQuery>
    {
        private const int MinimumEventId = 1;
        private const int MaximumEventId = 38;
        public GetByEventIdQueryValidation(IGetByEventIdQuery context) : base(context) { }
        public override bool IsValid => Context.EventId >= MinimumEventId && Context.EventId <= MaximumEventId;
        public override string Message => $"{nameof(Context.EventId)} must be between {MinimumEventId} and {MaximumEventId}";
    }
}
