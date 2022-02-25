using Fpl.Client.Models.Entries;
using Fpl.Client.Queries.Entries;
using Fpl.Client.Validation;
using Fpl.Client.Validation.Entries;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Fpl.Client.Clients
{
    public class EntryClient : Client, IEntryClient
    {
        public EntryClient(HttpClient client, ILogger<EntryClient> logger = null) : base(client, logger) { }
        public async ValueTask<Entry> GetEntryAsync(int entryId, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetEntryAsync)} invoked");

            var query = new GetEntryQuery { EntryId = entryId };
            var validation = new GetByEntryIdQueryValidation(query);
            var validations = new Validations(new IValidation[] { validation });

            Validate(validations);

            try
            {
                return await GetAsync<Entry>(query, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var paramName = nameof(entryId);
                Exception exception = new ArgumentException($"{paramName} does not exist", paramName, ex);
                if (ex.StatusCode != HttpStatusCode.NotFound)
                {
                    exception = ex;
                }
                _logger?.LogError(exception, "{message}", exception.Message);
                throw exception;
            }
        }

        public async ValueTask<EntryEventPicks> GetEntryEventPicksAsync(int entryId, int eventId, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetEntryEventPicksAsync)} invoked");

            var query = new GetEntryEventPicksQuery { EntryId = entryId, EventId = eventId };
            var entryValidation = new GetByEntryIdQueryValidation(query);
            var eventValidation = new GetByEventIdQueryValidation(query);
            var validations = new Validations(new IValidation[] { entryValidation, eventValidation });

            Validate(validations);

            try
            {
                return await GetAsync<EntryEventPicks>(query,  cancellationToken);
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