using Microsoft.Extensions.Caching.Distributed;
using Serilog;
using Ultimate.Fpl.Ui.Extensions;
using Ultimate.Fpl.Ui.Models.Entries;
using Ultimate.Fpl.Ui.Models.General;
using ILogger = Serilog.ILogger;

namespace Ultimate.Fpl.Ui.Services
{
    public class CacheService : ICacheService
    {
        private class Keys
        {
            public const string Data = "Data";
            public const string Entry = "Entry";
            public const string TeamPlayers = "TeamPlayers";
        }
        private readonly IDistributedCache _cache;
        private readonly ILogger _logger;
        private readonly DistributedCacheEntryOptions _options = new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1) };

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
            _logger = Log.ForContext<CacheService>();
        }

        public Task<Data> GetDataAsync(CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(GetDataAsync)} invoked");
            return _cache.GetAsync<Data>(Keys.Data, cancellationToken);
        }

        public Task SetDataAsync(Data data, CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(SetDataAsync)} invoked");
            return _cache.SetAsync(Keys.Data, data, _options, cancellationToken);
        }

        public Task<EntryEventPicks> GetEntryEventPicksAsync(int entryId, int eventId, CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(GetEntryEventPicksAsync)} invoked");
            return _cache.GetAsync<EntryEventPicks>($"{Keys.TeamPlayers}.{entryId}.{eventId}", cancellationToken);
        }

        public Task SetEntryEventPicksAsync(int entryId, int eventId, EntryEventPicks team, CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(SetEntryEventPicksAsync)} invoked");
            return _cache.SetAsync($"{Keys.TeamPlayers}.{entryId}.{eventId}", team, _options, cancellationToken);
        }

        public Task<Entry> GetEntryAsync(int entryId, CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(GetEntryAsync)} invoked");
            return _cache.GetAsync<Entry>($"{Keys.Entry}.{entryId}", cancellationToken);
        }

        public Task SetEntryAsync(int entryId, Entry team, CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(SetEntryAsync)} invoked");
            return _cache.SetAsync($"{Keys.Entry}.{entryId}", team, _options, cancellationToken);
        }
    }
}