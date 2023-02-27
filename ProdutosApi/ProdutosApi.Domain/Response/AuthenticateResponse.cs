using ProdutosApi.Domain.Enums;
using ProdutosApi.Model;

namespace ProdutosApi.Domain.Response
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
    }
}
