using ProdutosApi.Domain.Response;
using ProdutosApi.Model;

namespace ProdutosApi.Application.Interfaces
{
    public interface IAuthAppService
    {
        Task<User> GetUserbyIdAsync(int id);
        Task<AuthenticateResponse> GetTokenAsync(string userMail, string password);
    }
}
