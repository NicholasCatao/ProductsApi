using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Infrastructure.Cache.Service;

namespace ProdutosApi.Infrastructure.Cache
{
    public static class DistributedCache
    {
        
        public static void UseCache(this IServiceCollection services, IConfiguration configuration )
        {

            services.RedisConfiguration(configuration);
            services.RedisCacheService();
        }

        public static void RedisConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["redisConfiguration:connection"];
                options.InstanceName = configuration["redisConfiguration:instance"];
            });
        }

        public static void RedisCacheService(this IServiceCollection services)
        {
            services.AddScoped<ICacheService, CacheService>();
        }

    }
}