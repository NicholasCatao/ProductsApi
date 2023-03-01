using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProdutosApi.Domain.Enums;
using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Domain.Response;
using ProdutosApi.Infrastructure.CrossCutting.Model;
using ProdutosApi.Infrastructure.InfraDb.Interfaces;
using ProdutosApi.Model;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;
using static Dapper.SqlMapper;

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

        public async Task<User> GetUserbyIdAsync(int id)
        {
            return await _authRepository.GetUserbyIdAsync(id);
        }



        public async Task<AuthenticateResponse> GetTokenAsync(string usermail, string password)
        {
            var user = await _authRepository.GetUserAsync(usermail, password);

            if (user is null) throw new ArgumentException("xxxxxx");

            var token = GenerateJwtToken(user);

            return new AuthenticateResponse
            {
                Id = user.Id,
                Token = token,
                Role = Enum.GetName(typeof(Role), user.Role)
            };

        }


        //private string GenerateJwtToken(User user)
        //{
        //    // generate token that is valid for 7 days
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_options);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new List<Claim>
        //        {
        //            new Claim("id", user.Id.ToString()),
        //            new Claim(ClaimTypes.Role, user.Role.ToString()),
        //        }),
        //        //Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options); // Private Key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim("id", user.Id.ToString()),
                     new Claim(ClaimTypes.Role, Enum.GetName(typeof(Role), user.Role)),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
