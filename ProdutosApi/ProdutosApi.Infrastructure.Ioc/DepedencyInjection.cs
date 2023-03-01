using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Application.Mappers;
using ProdutosApi.Application.Service;
using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Domain.Services;
using ProdutosApi.Domain.Validators;
using ProdutosApi.Infrastructure.Common;
using ProdutosApi.Infrastructure.Common.Interfaces;
using ProdutosApi.Infrastructure.CrossCutting.Model;
using ProdutosApi.Infrastructure.InfraDb.DbContext;
using ProdutosApi.Infrastructure.InfraDb.Interfaces;
using ProdutosApi.Infrastructure.InfraDb.Respository;

namespace ProdutosApi.Infrastructure.Ioc
{
    public static class DepedencyInjection
    {
        public static void RegisterServicesInjection(this IServiceCollection services) 
        {
           // services.UseAppSeetings(configuration);
            services.UseApplications();
            services.UseServices();
            services.UseRepositories();
            services.UserMappers();
            services.UseValidations();
            services.UseJwt();
        }

        public static void UseAppSeetings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
        }

        public static void UseApplications(this IServiceCollection services)
        {
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IProdutoMapper, ProdutoMapper>();
        }

        public static void UseServices(this IServiceCollection services)
        {
            services.AddScoped<DapperContext>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        public static void UseRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
        }

        public static void UserMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProdutoMapper));
            //services.AddAutoMapper<ProdutoToProdutoDtoProfile>();
        }

        public static void UseJwt(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();
        }


        public static void UseValidations(this IServiceCollection services)
        {
            services.AddScoped<IProdutoValidator, ProdutoValidator>();
        }
      
    }
}
