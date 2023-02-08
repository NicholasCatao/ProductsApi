using Microsoft.Extensions.DependencyInjection;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Application.Mappers;
using ProdutosApi.Application.Service;
using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Domain.Services;
using ProdutosApi.Domain.Validators;
using ProdutosApi.Infrastructure.InfraDb.DbContext;
using ProdutosApi.Infrastructure.InfraDb.Interfaces;
using ProdutosApi.Infrastructure.InfraDb.Respository;

namespace ProdutosApi.Infrastructure.Ioc
{
    public static class DepedencyInjection
    {
        public static void RegisterServicesInjection(this IServiceCollection services)
        {
            services.UseApplications();
            services.UseServices();
            services.UseRepositories();
            services.UserMappers();
            services.UseValidations();
        }

        public static void UseApplications(this IServiceCollection services)
        {
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IProdutoMapper, ProdutoToProdutoDtoProfile>();
        }

        public static void UseServices(this IServiceCollection services)
        {
            services.AddScoped<DapperContext>();
            services.AddScoped<IProdutoService, ProdutoService>();
        }

        public static void UseRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }

        public static void UserMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProdutoToProdutoDtoProfile));
            //services.AddAutoMapper<ProdutoToProdutoDtoProfile>();
        }


        public static void UseValidations(this IServiceCollection services)
        {
            services.AddScoped<IProdutoValidator, ProdutoValidator>();
        }
    }
}
