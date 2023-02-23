using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Domain.Response;
using ProdutosApi.Infrastructure.CrossCutting.Model;
using ProdutosApi.Infrastructure.InfraDb.Interfaces;
using ProdutosApi.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProdutosApi.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly string _options;
        

        public AuthService(IAuthRepository authRepository, IOptions<AppSettings> options)
        {
            _authRepository = authRepository;
            _options = options.Value.Secret;
        }

        public async Task<AuthenticateResponse> GetTokenAsync(string usermail, string password)
        {
            var user = await _authRepository.GetUserAsync(usermail, password);

            if (user is null) throw new ArgumentException("xxxxxx");

            var token =  GenerateJwtToken(user);

            return new AuthenticateResponse
            {
                Id = user.Id,
                Token = token,
                Role = (Enums.Role)user.Role
            };

        }
            

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
