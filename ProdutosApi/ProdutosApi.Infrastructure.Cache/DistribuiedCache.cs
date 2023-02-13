using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProdutosApi.Infrastructure.Cache
{
    public static class DistribuiedCache
    {
        public static void UseCache(this IServiceCollection services, IConfiguration configuration )
        {
           
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["REDIS_CONFIGURATION"];
                options.InstanceName = configuration["REDIS_INSTANCE"];
            });
        }
    }
}