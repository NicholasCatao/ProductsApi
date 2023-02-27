using ProdutosApi.Model;

namespace ProdutosApi.Infrastructure.Common.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public string? ValidateJwtToken(string token);
    }
}
