using ProdutosApi.Domain.Enums;
using ProdutosApi.Model;

namespace ProdutosApi.Domain.Response
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Role { get; set; }
        public string Token { get; set; }
    }
}
