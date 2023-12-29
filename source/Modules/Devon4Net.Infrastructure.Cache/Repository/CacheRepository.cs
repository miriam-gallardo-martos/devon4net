using Devon4Net.Infrastructure.Cache.Options;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Devon4Net.Infrastructure.Cache.Repository
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private DistributedCacheEntryOptions options;

        public CacheRepository(IDistributedCache distributedCache, IOptions<CacheOptions> cacheOptions)
        {
            _distributedCache = distributedCache;

            options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = cacheOptions.Value.ExpirationInSecondsRelativeToNow > 0 ? TimeSpan.FromSeconds(cacheOptions.Value.ExpirationInSecondsRelativeToNow) : null,
                SlidingExpiration = cacheOptions.Value.SlidingExpirationInSeconds > 0 ? TimeSpan.FromSeconds(cacheOptions.Value.SlidingExpirationInSeconds) : null
            };
        }

        public async Task<T?> GetData<T>(string key)
        {
            var value = await _distributedCache.GetStringAsync(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        public async Task SetData<T>(string key, T value)
        {
            await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(value), options);
        }

        public async Task RemoveData(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    }
}
