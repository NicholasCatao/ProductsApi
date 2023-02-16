using ProdutosApi.Model;

namespace ProdutosApi.Domain.Interfaces
{
    public interface ICacheService
    {
        Task SetAsync(string Key, string Value);
        Task<string>GetAsync(string Key);
    }
}
