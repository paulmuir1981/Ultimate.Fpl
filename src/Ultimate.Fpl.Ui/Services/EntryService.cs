using AutoMapper;
using Fpl.Client.Clients;
using Serilog;
using Ultimate.Fpl.Ui.Models.Entries;
using ILogger = Serilog.ILogger;

namespace Ultimate.Fpl.Ui.Services
{
    public class EntryService : IEntryService
    {
        private class Keys
        {
            public const string MyEntryId = "MyEntryId";
            public const string MyEntryPlayerName = "MyEntryPlayerName";
        }
        private readonly ICacheService _cacheService;
        private readonly IDataService _dataService;
        private readonly IEntryClient _client;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IResponseCookies _responseCookies;
        private readonly IRequestCookieCollection _requestCookies;

        public EntryService(ICacheService cacheService, IEntryClient client, IMapper mapper, ILogger logger, IDataService dataService, IHttpContextAccessor httpContextAccessor)
        {
            _cacheService = cacheService;
            _client = client;
            _mapper = mapper;
            _logger = Log.ForContext<EntryService>();
            _dataService = dataService;
            _responseCookies = httpContextAccessor.HttpContext.Response.Cookies;
            _requestCookies = httpContextAccessor.HttpContext.Request.Cookies;
        }

        public int MyEntryId 
        { 
            get => int.TryParse(_requestCookies[Keys.MyEntryId], out var entryId) ? entryId : 0;
            private set => _responseCookies.Append(Keys.MyEntryId, value.ToString());
        }

        public string MyEntryPlayerName
        {
            get => _requestCookies[Keys.MyEntryPlayerName];
            private set => _responseCookies.Append(Keys.MyEntryPlayerName, value);
        }

        public bool IsMyEntrySet => MyEntryId > 0;

        public async Task<bool> SetMyEntryAsync(int entryId, CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(SetMyEntryAsync)} invoked");
            try
            {
                var entry = await GetEntryAsync(entryId, cancellationToken);
                MyEntryId = entryId;
                MyEntryPlayerName = entry.PlayerFullName;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ClearMyEntry()
        {
            _logger.Information($"{nameof(ClearMyEntry)} invoked");
            _responseCookies.Delete(Keys.MyEntryId);
            _responseCookies.Delete(Keys.MyEntryPlayerName);
        }

        public async Task<Entry> GetEntryAsync(int entryId, CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(GetEntryAsync)} invoked");
            var result = await _cacheService.GetEntryAsync(entryId, cancellationToken);

            if (result == null)
            {
                var entry = await _client.GetEntryAsync(entryId, cancellationToken);
                result = _mapper.Map<Entry>(entry);
                await _cacheService.SetEntryAsync(entryId, result, cancellationToken);
            }

            return result;
        }

        public async Task<EntryEventPicks> GetEntryEventPicksAsync(int entryId, int eventId, CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(GetEntryEventPicksAsync)} invoked");
            var result = await _cacheService.GetEntryEventPicksAsync(entryId, eventId, cancellationToken);

            if (result == null)
            {
                var data = await _dataService.GetAsync(cancellationToken);
                var eventPicks = await _client.GetEntryEventPicksAsync(entryId, eventId, cancellationToken);
                result = _mapper.Map<EntryEventPicks>(eventPicks);
                _mapper.Map(eventPicks.EntryHistory, result);
                result.Picks = result.Picks
                    .Join(
                        data.Players,
                        rp => rp.Id,
                        dp => dp.Id,
                        (rp, dp) => _mapper.Map(dp, rp))
                    .ToList();
                result.EntryId = entryId;
                await _cacheService.SetEntryEventPicksAsync(entryId, eventId, result, cancellationToken);
            }

            return result;
        }

        public async Task<EntryEventPicks> GetEntryCurrentEventPicksAsync(int entryId, CancellationToken cancellationToken = default)
        {
            _logger.Information($"{nameof(GetEntryCurrentEventPicksAsync)} invoked");
            var data = await _dataService.GetAsync(cancellationToken);
            return await GetEntryEventPicksAsync(entryId, data.Gameweeks.FirstOrDefault(x => x.IsCurrent)?.Id ?? 0, cancellationToken);
        }

        public Task<Entry> GetMyEntryAsync(CancellationToken cancellationToken = default)
        {
            return GetEntryAsync(MyEntryId, cancellationToken);
        }

        public Task<EntryEventPicks> GetMyEntryEventPicksAsync(int eventId, CancellationToken cancellationToken = default)
        {
            return GetEntryEventPicksAsync(MyEntryId, eventId, cancellationToken);
        }

        public Task<EntryEventPicks> GetMyEntryCurrentEventPicksAsync(CancellationToken cancellationToken = default)
        {
            return GetEntryCurrentEventPicksAsync(MyEntryId, cancellationToken);
        }
    }
}