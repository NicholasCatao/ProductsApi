using ProdutosApi.Model;

namespace ProdutosApi.Infrastructure.InfraDb.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterProdutosAsync();
        Task<Produto> ObterProdutoAsync(int id);
        Task<int> CadastrarProdutoAsync(Produto produto);
        Task AlterarProdutoAsync(Produto produto, int id);
        Task CancelarProdutoAsync(int codigo, bool situacao);
    }
}
