using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProdutosApi.Infrastructure.CrossCutting.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProdutosApi.Infrastructure.InfraDb.DbContext
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(IOptions<AppSettings> appsettings)
        {
            _connectionString = appsettings.Value.SqlConnection;
        }
        public IDbConnection CreateSqlConnection()
            => new SqlConnection(_connectionString);
    }
}
