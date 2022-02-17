using FluentValidation;
using Fpl.Client.Models.Entries;
using Fpl.Client.Queries.Entries;

namespace Fpl.Client.Validators.Entries
{
    public class GetEntryEventPicksQueryValidator : AbstractValidator<GetEntryEventPicksQuery>
    {
        private const int MinimumEventId = 1;
        private const int MaximimEventId = 38;
        public GetEntryEventPicksQueryValidator()
        {
            Include(new GetByEntryIdQueryValidator<GetEntryEventPicksQuery, EntryEventPicks>());
            RuleFor(query => query.EventId).InclusiveBetween(MinimumEventId, MaximimEventId);
        }
    }
}