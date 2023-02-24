using ProdutosApi.Application.Interfaces;
using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Domain.Response;
using ProdutosApi.Model;

namespace ProdutosApi.Application.Service
{
    public class AuthAppService: IAuthAppService
    {
        private readonly IAuthService _authService;

        public AuthAppService(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<User> GetUserbyIdAsync(int id)
        {
            return await _authService.GetUserbyIdAsync(id);
        }
        public async Task<AuthenticateResponse> GetToken(string userMail, string password)
        {
            return await _authService.GetTokenAsync(userMail, password);
        }
    }
}
