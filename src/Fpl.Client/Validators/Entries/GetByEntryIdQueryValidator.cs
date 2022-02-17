using FluentValidation;
using Fpl.Client.Queries.Entries;

namespace Fpl.Client.Validators.Entries
{
    public class GetByEntryIdQueryValidator<TQuery, TResponse> : AbstractValidator<TQuery> where TQuery : IGetByEntryIdQuery<TResponse>
    {
        private const int MinimumEntryId = 1;

        public GetByEntryIdQueryValidator()
        {
            RuleFor(query => query.EntryId).GreaterThanOrEqualTo(MinimumEntryId);
        }
    }
}