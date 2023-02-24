using ProdutosApi.Model;

namespace ProdutosApi.Infrastructure.Common.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public int? ValidateJwtToken(string token);
    }
}
