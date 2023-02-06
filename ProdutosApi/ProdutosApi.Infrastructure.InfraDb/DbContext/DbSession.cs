using System.Data;

namespace ProdutosApi.Infrastructure.InfraDb.DbContext
{
    public sealed class DbSession: IDisposable
    {
        private readonly IDbConnection _connection;
        public IDbTransaction  _transaction { get; set; }

        public DbSession()
        {
            _connection = connection;
            _transaction = transaction;
        }
    }
}
