using System.Data;

namespace ProdutosApi.Domain.Sessions
{
    public interface IDbSession
    {
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
    }
}
