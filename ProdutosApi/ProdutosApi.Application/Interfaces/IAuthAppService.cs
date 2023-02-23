using ProdutosApi.Domain.Response;

namespace ProdutosApi.Application.Interfaces
{
    public interface IAuthAppService
    {
        Task<AuthenticateResponse> GetToken(string userMail, string password);
    }
}
