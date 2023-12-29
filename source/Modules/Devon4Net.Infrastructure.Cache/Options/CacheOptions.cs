namespace Devon4Net.Infrastructure.Cache.Options
{
    public class CacheOptions
    {
        public bool EnableRedisCache { get; set; }
        public bool EnableOutputCache { get; set; }
        public int ExpirationInSeconds { get; set; }
        public int SlidingExpirationInSeconds { get; set; }
        public string? RedisInstanceName { get; set; }        
    }
}
