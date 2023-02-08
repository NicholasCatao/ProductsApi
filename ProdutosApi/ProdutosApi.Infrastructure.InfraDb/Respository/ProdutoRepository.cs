using Dapper;
using ProdutosApi.Infrastructure.InfraDb.DbContext;
using ProdutosApi.Infrastructure.InfraDb.Interfaces;
using ProdutosApi.Model;
using System.Data;

namespace ProdutosApi.Infrastructure.InfraDb.Respository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DapperContext _context;

        public ProdutoRepository(DapperContext context)
        {
            _context = context;
        }

        #region retorno unico
        //public async Task<List<Produto>> ObterProdutosAsync()
        //{

        //    var query = $@"  SELECT p.*, f.*
        //                  FROM Autoglass.dbo.Produto p  JOIN Fornecedor  f on f.CNPJ = p.Fornecedor";

        //    using(var connection = _context.CreateSqlConnection())
        //    {
        //        var x = await connection.QueryAsync<Produto, Fornecedor, Produto>(query, (produto, fornecedor) => { produto.Fornecedor = fornecedor; return produto; }, splitOn: "Fornecedor");

        //        return x.ToList();
        //    }
        //}
        #endregion


        public async Task<IEnumerable<Produto>> ObterProdutosAsync()
        {

            var query = $@"SELECT p.Codigo as Codigo
                                      ,p.Descricao as Descricao
                                      ,p.Situacao as Situacao
                                      ,p.Fabricacao as Fabricacao
                                      ,p.Validade  as Validade
	                                  ,f.CNPJ as CNPJ
	                                  ,f.CodFornecedor as CodFornecedor
	                                  ,f.DescricaoFornecedor as DescricaoFornecedor
                                   FROM Autoglass.dbo.Produto p JOIN Fornecedor  f on f.CNPJ = p.Fornecedor";

            using (var connection = _context.CreateSqlConnection())
            {
                var result = await connection.QueryAsync<Produto>(query);

                return result;
            }
        }

        public async Task<Produto> ObterProdutoAsync(int id)
        {
            var query = $@"SELECT p.Codigo as Codigo
                                      ,p.Descricao as Descricao
                                      ,p.Situacao as Situacao
                                      ,p.Fabricacao as Fabricacao
                                      ,p.Validade  as Validade
	                                  ,f.CNPJ as CNPJ
	                                  ,f.CodFornecedor as CodFornecedor
	                                  ,f.DescricaoFornecedor as DescricaoFornecedor
                                   FROM Autoglass.dbo.Produto p JOIN Fornecedor  f on f.CNPJ = p.Fornecedor
                                     Where p.Codigo = @id";

            using (var connection = _context.CreateSqlConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Produto>(query, new { id });
            }
        }
        public async Task<int> CadastrarProdutoAsync(Produto produto)
        {

            var query = $@"
                        INSERT INTO Autoglass.dbo.Produto  (Descricao, Situacao, Fabricacao, Validade, Fornecedor)
                        VALUES(@Descricao, @Situacao, @Fabricacao, @Validade, @Fornecedor);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Descricao", produto.Descricao, DbType.String);
            parameters.Add("Situacao", produto.Situacao, DbType.Boolean);
            parameters.Add("Fabricacao", produto.Fabricacao, DbType.DateTime);
            parameters.Add("Validade", produto.Validade, DbType.DateTime);
            parameters.Add("Fornecedor", produto.Cnpj, DbType.Int64);

            using (var connection = _context.CreateSqlConnection())
            {
                var result = await connection.ExecuteScalarAsync(query, parameters);
                return Convert.ToUInt16(result);
            }
        }
        public async Task AlterarProdutoAsync(Produto produto, int id)
        {
            var query = $@"UPDATE Autoglass.dbo.Produto 
                                        SET Descricao =@Descricao,
                                        Situacao = @Situacao,
                                        Fabricacao =@Fabricacao,
                                        Validade =@Validade, 
                                        Fornecedor=@Fornecedor
                          WHERE Codigo =@id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            parameters.Add("Descricao", produto.Descricao, DbType.String);
            parameters.Add("Situacao", produto.Situacao, DbType.Boolean);
            parameters.Add("Fabricacao", produto.Fabricacao, DbType.DateTime);
            parameters.Add("Validade", produto.Validade, DbType.DateTime);
            parameters.Add("Fornecedor", produto.Cnpj, DbType.Int64);

            using (var connection = _context.CreateSqlConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task CancelarProdutoAsync(int codigo, bool situacao)
        {
            var query = $@"UPDATE Autoglass.dbo.Produto  SET Situacao = @Situacao WHERE Codigo =@Codigo";

            var parameters = new DynamicParameters();
            parameters.Add("Codigo", codigo, DbType.Int64);
            parameters.Add("Situacao", situacao, DbType.Boolean);

            using (var connection = _context.CreateSqlConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
