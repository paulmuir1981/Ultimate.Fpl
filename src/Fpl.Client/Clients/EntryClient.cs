using FluentValidation;
using Fpl.Client.Models.Entries;
using Fpl.Client.Queries;
using Fpl.Client.Queries.Entries;
using Fpl.Client.Validators.Entries;
using Microsoft.Extensions.Logging;

namespace Fpl.Client.Clients
{
    public class EntryClient : BaseClient, IEntryClient
    {
        private const string EntryUriFormat = BaseUri + "entry/{0}/";
        private const string EventPicksUriFormat = EntryUriFormat + "event/{1}/picks/";
        private readonly IValidator<GetEntryQuery> _getEntryValidator = new GetEntryQueryValidator();
        private readonly IValidator<GetEntryEventPicksQuery> _getEntryEventPicksValidator = new GetEntryEventPicksQueryValidator();
        public EntryClient(HttpClient client, ILogger<EntryClient> logger = null) : base(client, logger) { }

        public async ValueTask<Entry> GetEntryAsync(int entryId, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetEntryAsync)} invoked");
            try
            {
                return await GetAsync<GetEntryQuery, Entry>(new GetEntryQuery { EntryId = entryId }, _getEntryValidator, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var exception = new ArgumentException($"{nameof(entryId)} does not exist", ex);
                _logger?.LogError(exception, "{message}", exception.Message);
                throw exception;
            }
        }

        public async ValueTask<EntryEventPicks> GetEntryEventPicksAsync(int entryId, int eventId, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetEntryEventPicksAsync)} invoked");
            try
            {
                return await GetAsync<GetEntryEventPicksQuery, EntryEventPicks>(new GetEntryEventPicksQuery { EntryId = entryId, EventId = eventId }, _getEntryEventPicksValidator,  cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var exception = new ArgumentException($"{nameof(entryId)} or {nameof(eventId)} does not exist", ex);
                _logger?.LogError(exception, "{message}", exception.Message);
                throw exception;
            }
        }
    }
}