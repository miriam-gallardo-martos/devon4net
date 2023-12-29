using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Devon4Net.Infrastructure.Cache.Options;
using Devon4Net.Infrastructure.Common.Constants;
using Devon4Net.Infrastructure.Common.Handlers;
using Devon4Net.Infrastructure.Cache.Repository;

namespace Devon4Net.Infrastructure.Cache
{
    public static class CacheConfiguration
    {
        public static void SetupRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            var cacheOptions = services.GetTypedOptions<CacheOptions>(configuration, OptionsDefinition.Cache);
            if (cacheOptions == null || !cacheOptions.EnableDistributedCache) return;

            //builder.AddRedisOutputCache("RedisConnection");
            services.AddStackExchangeRedisCache(
                options =>
                {
                    options.Configuration = configuration.GetConnectionString("RedisConnection");
                });

            services.AddSingleton<ICacheRepository, CacheRepository>();

            //builder.Services.AddStackExchangeRedisOutputCache(opt =>
            //{
            //    opt.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
            //    opt.InstanceName = builder.Configuration["InstanceName"];
            //});
            //builder.Services.AddOutputCache();
        }
    }
}
