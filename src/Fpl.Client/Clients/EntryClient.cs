﻿using Fpl.Client.Models.Entries;
using Serilog;

namespace Fpl.Client.Clients
{
    public class EntryClient : BaseClient, IEntryClient
    {
        private const string EntryUriFormat = BaseUri + "entry/{0}/";
        private const string EventPicksUriFormat = EntryUriFormat + "event/{1}/picks/";
        public EntryClient(HttpClient client) : base(client, Log.ForContext<EntryClient>()) { }

        public async ValueTask<Entry> GetEntryAsync(int entryId, CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(GetEntryAsync)} invoked");
            if (entryId <= 0)
            {
                var exception = new ArgumentOutOfRangeException(nameof(entryId), entryId, $"{nameof(entryId)} should be greater than 0");
                _logger.Error(exception, exception.Message);
                throw exception;
            }
            try
            {
                return await GetAsync<Entry>(string.Format(EntryUriFormat, entryId), cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var exception = new ArgumentException($"{nameof(entryId)} does not exist", ex);
                _logger.Error(exception, exception.Message);
                throw exception;
            }
        }

        public async ValueTask<EntryEventPicks> GetEntryEventPicksAsync(int entryId, int eventId, CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(GetEntryEventPicksAsync)} invoked");
            if (entryId <= 0)
            {
                var exception = new ArgumentOutOfRangeException(nameof(entryId), entryId, $"{nameof(entryId)} should be greater than 0");
                _logger.Error(exception, exception.Message);
                throw exception;
            }
            if (eventId < 1 || eventId > 38)
            {
                var exception =  new ArgumentOutOfRangeException(nameof(eventId), eventId, $"{nameof(eventId)} should be between 1 and 38");
                _logger.Error(exception, exception.Message);
                throw exception;
            }
            try
            {
                return await GetAsync<EntryEventPicks>(string.Format(EventPicksUriFormat, entryId, eventId), cancellationToken);
            }
            catch (HttpRequestException ex)
            {
                var exception = new ArgumentException($"{nameof(entryId)} or {nameof(eventId)} does not exist", ex);
                _logger.Error(exception, exception.Message);
                throw exception;
            }
        }
    }
}