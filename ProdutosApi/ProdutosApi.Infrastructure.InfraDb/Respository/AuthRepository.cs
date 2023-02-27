using Dapper;
using ProdutosApi.Infrastructure.InfraDb.DbContext;
using ProdutosApi.Infrastructure.InfraDb.Interfaces;
using ProdutosApi.Model;
using System.Data;

namespace ProdutosApi.Infrastructure.InfraDb.Respository
{
    public class AuthRepository: IAuthRepository
    {
        private readonly DapperContext _context;

        public AuthRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserbyIdAsync(int id)
        {
            var query = "SELECT * FROM UserInfo WHERE ID = @ID";

            using (var connection = _context.CreateSqlConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<User>(query, new { id });
            }
        }

        public async Task<User> GetUserAsync(string email, string password)
        {
            var query = "SELECT * FROM UserInfo WHERE EMAIL = @email and PASSWORD = @password";

            var parameters = new DynamicParameters();
            parameters.Add("email", email, DbType.String);
            parameters.Add("password", password, DbType.String);
            
           using(var connection = _context.CreateSqlConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<User>(query, parameters);
            }
        }
    }
}
