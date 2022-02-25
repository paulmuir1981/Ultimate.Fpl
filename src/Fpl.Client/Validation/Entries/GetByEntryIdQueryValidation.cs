using Fpl.Client.Queries.Entries;

namespace Fpl.Client.Validation.Entries
{
    public class GetByEntryIdQueryValidation : Validation<IGetByEntryIdQuery>
    {
        private const int MinimumEntryId = 1;
        public GetByEntryIdQueryValidation(IGetByEntryIdQuery context) : base(context) { }
        public override bool IsValid => Context.EntryId >= MinimumEntryId;
        public override string Message => $"{nameof(Context.EntryId)} must be at least {MinimumEntryId}";
    }
}