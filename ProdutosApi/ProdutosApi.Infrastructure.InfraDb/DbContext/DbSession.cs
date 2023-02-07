using Microsoft.Extensions.Options;
using ProdutosApi.Infrastructure.CrossCutting.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProdutosApi.Infrastructure.InfraDb.DbContext
{
    public sealed class DbSession: IDisposable
    {
        
        public readonly IOptions<AppSettings> _options;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession()
        {
            Connection = new SqlConnection(_options.Value.SqlConnection);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
