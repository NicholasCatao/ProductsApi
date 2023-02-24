using ProdutosApi.Model;

namespace ProdutosApi.Infrastructure.InfraDb.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> GetUserbyIdAsync(int id);
        Task<User> GetUserAsync(string email, string password);
    }
}
