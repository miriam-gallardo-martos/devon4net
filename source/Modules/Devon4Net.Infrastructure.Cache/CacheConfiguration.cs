using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Devon4Net.Infrastructure.Cache.Options;
using Devon4Net.Infrastructure.Common.Constants;
using Devon4Net.Infrastructure.Common.Handlers;
using Devon4Net.Infrastructure.Cache.Repository;
using Microsoft.AspNetCore.Builder;

namespace Devon4Net.Infrastructure.Cache
{
    public static class CacheConfiguration
    {
        private static CacheOptions? CacheOptions { get; set; }

        public static void SetupCache(this IServiceCollection services, IConfiguration configuration)
        {
            CacheOptions = services.GetTypedOptions<CacheOptions>(configuration, OptionsDefinition.Cache);
            if (CacheOptions == null) return;

            if (CacheOptions.EnableOutputCache)
            {
                if (CacheOptions.EnableRedisCache)
                {
                    services.AddStackExchangeRedisOutputCache(options =>
                    {
                        options.Configuration = configuration.GetConnectionString("Redis");
                        options.InstanceName = string.IsNullOrEmpty(CacheOptions.RedisInstanceName) ? null : configuration[CacheOptions.RedisInstanceName];
                    });
                }

                services.AddOutputCache(options =>
                {
                    options.AddBasePolicy(builder =>
                        builder.Expire(TimeSpan.FromSeconds(CacheOptions.ExpirationInSeconds)));
                });
            }
            else if (CacheOptions.EnableRedisCache)
            {
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = configuration.GetConnectionString("Redis");
                    options.InstanceName = string.IsNullOrEmpty(CacheOptions.RedisInstanceName) ? null : configuration[CacheOptions.RedisInstanceName];
                });

                services.AddSingleton<ICacheRepository, CacheRepository>();
            }
        }

        public static void SetupCache(this IApplicationBuilder app)
        {
            if (CacheOptions == null) return;

            if (CacheOptions.EnableOutputCache)
            {
                app.UseOutputCache();
            }
        }
    }
}
