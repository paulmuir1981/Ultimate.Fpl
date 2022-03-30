using Fpl.Client.Models.Entries;
using Fpl.Client.Models.EntryEventPicks;
using EntryHistory = Fpl.Client.Models.EntryHistory.EntryHistory;
using Fpl.Client.Queries.Entries;
using Microsoft.Extensions.Logging;
using System.Net;
using Fpl.Client.Models.EntryTransfers;

namespace Fpl.Client.Clients
{
    public class EntryClient : Client, IEntryClient
    {
        public EntryClient(HttpClient client, ILogger<EntryClient> logger = null) : base(client, logger) { }
        public async ValueTask<Entry> GetEntryAsync(int entryId, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetEntryAsync)} invoked");

            var query = new GetEntryQuery { EntryId = entryId };
            query.Validate();

            try
            {
                return await GetAsync(query, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var paramName = nameof(entryId);
                Exception exception = new ArgumentException($"{paramName} ({entryId}) does not exist", paramName, ex);
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
            query.Validate();

            try
            {
                return await GetAsync(query, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var paramName = nameof(entryId);
                Exception exception = new ArgumentException($"{paramName} ({entryId}) does not exist", paramName, ex);
                if (ex.StatusCode != HttpStatusCode.NotFound)
                {
                    exception = ex;
                }
                _logger?.LogError(exception, "{message}", exception.Message);
                throw exception;
            }
        }

        public async ValueTask<EntryHistory> GetEntryHistoryAsync(int entryId, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetEntryHistoryAsync)} invoked");

            var query = new GetEntryHistoryQuery { EntryId = entryId };
            query.Validate();

            try
            {
                return await GetAsync(query, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var paramName = nameof(entryId);
                Exception exception = new ArgumentException($"{paramName} ({entryId}) does not exist", paramName, ex);
                if (ex.StatusCode != HttpStatusCode.NotFound)
                {
                    exception = ex;
                }
                _logger?.LogError(exception, "{message}", exception.Message);
                throw exception;
            }
        }

        public async ValueTask<List<EntryTransfer>> GetEntryTransfersAsync(int entryId, CancellationToken cancellationToken = default)
        {
            _logger?.LogInformation($"{nameof(GetEntryTransfersAsync)} invoked");

            var query = new GetEntryTransfersQuery { EntryId = entryId };
            query.Validate();

            try
            {
                return await GetAsync(query, cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var paramName = nameof(entryId);
                Exception exception = new ArgumentException($"{paramName} ({entryId}) does not exist", paramName, ex);
                if (ex.StatusCode != HttpStatusCode.NotFound)
                {
                    exception = ex;
                }
                _logger?.LogError(exception, "{message}", exception.Message);
                throw exception;
            }
        }
    }
}