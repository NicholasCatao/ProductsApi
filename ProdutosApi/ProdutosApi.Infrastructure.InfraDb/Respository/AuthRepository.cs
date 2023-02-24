using Dapper;
using ProdutosApi.Infrastructure.InfraDb.DbContext;
using ProdutosApi.Infrastructure.InfraDb.Interfaces;
using ProdutosApi.Model;

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
            var query = "";

            var parameters = new DynamicParameters();


            using (var connection = _context.CreateSqlConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<User>(query);
            }
        }


        public async Task<User> GetUserAsync(string user, string password)
        {
            var query = "";

            var parameters = new DynamicParameters();

            
           using(var connection = _context.CreateSqlConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<User>(query);
            }
        }
    }
}
