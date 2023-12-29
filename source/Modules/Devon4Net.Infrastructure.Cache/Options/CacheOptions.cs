namespace Devon4Net.Infrastructure.Cache.Options
{
    public class CacheOptions
    {
        public bool EnableDistributedCache { get; set; }
        public int ExpirationInSecondsRelativeToNow { get; set; }
        public int SlidingExpirationInSeconds { get; set; }
    }
}
