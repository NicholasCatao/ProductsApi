using ProdutosApi.Application.DTO.DTO;
using ProdutosApi.Domain.Response;
using ProdutosApi.Domain.Resquest;
using ProdutosApi.Model;

namespace ProdutosApi.Application.Interfaces
{
    public interface IProdutoAppService
    {
        Task<Paginacao<ProdutoDTO>> ObterProdutosAsync(FiltroProduto filtro);
        Task<ProdutoDTO> ObterProdutoAsync(int id);
        Task<int> CadastrarProdutoAsync(Produto produto);
        Task<bool> AlterarProdutoAsync(Produto produto, int id);
        Task<bool> CancelarProdutoAsync(int codigo, bool situacao);
    }
}
