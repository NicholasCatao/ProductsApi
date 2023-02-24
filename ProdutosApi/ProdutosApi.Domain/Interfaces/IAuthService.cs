using ProdutosApi.Domain.Response;
using ProdutosApi.Model;

namespace ProdutosApi.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<User> GetUserbyIdAsync(int id);
        Task<AuthenticateResponse> GetTokenAsync(string user, string password);
    }
}
