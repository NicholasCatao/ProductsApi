using ProdutosApi.Application.DTO.DTO;
using ProdutosApi.Model;

namespace ProdutosApi.Application.Interfaces
{
    public interface IProdutoMapper
    {
        ProdutoDTO MapToResponse(Produto produto);
        IEnumerable<ProdutoDTO> MapToResponse(IEnumerable<Produto> produto);
    }
}
