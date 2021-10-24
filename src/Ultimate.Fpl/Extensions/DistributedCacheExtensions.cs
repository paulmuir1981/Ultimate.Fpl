using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Serilog;

namespace Ultimate.Fpl.Extensions
{
    public static class DistributedCacheExtensions
    {
        public static async Task<TItem> GetAsync<TItem>(this IDistributedCache cache, string key, CancellationToken token = default) where TItem : class
        {
            var serialisedValue = await cache.GetStringAsync(key, token);

            if (!string.IsNullOrEmpty(serialisedValue))
            {
                try
                {
                    return JsonSerializer.Deserialize<TItem>(serialisedValue);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Error deserialising {serialisedValue}");
                }
            }

            return null;
        }
        public static Task SetAsync<TItem>(this IDistributedCache cache, string key, TItem value, CancellationToken token = default) where TItem : class
        {
            return cache.SetAsync(key, value, new DistributedCacheEntryOptions(), token);
        }

        public static Task SetAsync<TItem>(
            this IDistributedCache cache, 
            string key, 
            TItem value,
            DistributedCacheEntryOptions options, 
            CancellationToken token = default) where TItem : class
        {
            return cache.SetStringAsync(key, JsonSerializer.Serialize(value), options, token);
        }
    }
}