using ProdutosApi.Model;

namespace ProdutosApi.Domain.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ObterProdutosAsync();
        Task<Produto> ObterProdutoAsync(int id);
        Task<int> CadastrarProdutoAsync(Produto produto);
        Task<bool> AlterarProdutoAsync(Produto produto, int id);
        Task<bool> CancelarProdutoAsync(int codigo, bool situacao);
    }
}
