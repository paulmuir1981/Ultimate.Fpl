using Fpl.Client.Models.Entries;
using Fpl.Client.Queries.Entries;

namespace Fpl.Client.Validators.Entries
{
    public class GetEntryQueryValidator : GetByEntryIdQueryValidator<GetEntryQuery, Entry>
    {
    }
}