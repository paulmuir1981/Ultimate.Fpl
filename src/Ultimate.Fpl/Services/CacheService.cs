using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Ultimate.Fpl.Models;
using System.Threading;
using Ultimate.Fpl.Extensions;
using Serilog;

namespace Ultimate.Fpl.Services
{
    public class CacheService : ICacheService
    {
        public static class Keys
        {
            public const string Data = "Data";
        }
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options = new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1) };

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public Task<Data> GetDataAsync(CancellationToken cancellationToken = default)
        {
            Log.Information($"{nameof(GetDataAsync)} invoked");
            return _cache.GetAsync<Data>(Keys.Data, cancellationToken);
        }

        public Task SetDataAsync(Data data, CancellationToken cancellationToken = default)
        {
            Log.Information($"{nameof(SetDataAsync)} invoked");
            return _cache.SetAsync(Keys.Data, data, _options, cancellationToken);
        }
    }
}