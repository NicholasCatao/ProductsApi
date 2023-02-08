using ProdutosApi.Application.DTO.DTO;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Domain.Response;
using ProdutosApi.Domain.Resquest;
using ProdutosApi.Model;

namespace ProdutosApi.Application.Service
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoService _produtoService;
        private readonly IProdutoMapper _mapper;

        public ProdutoAppService(IProdutoService produtoService, IProdutoMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        public async Task<Paginacao<ProdutoDTO>> ObterProdutosAsync(FiltroProduto filtro)
        {
            var dados = _mapper.MapToResponse(await _produtoService.ObterProdutosAsync());

            return Paginacao<ProdutoDTO>.ToPagedList(dados, filtro.PageNumber, filtro.PageSize);
        }

        public async Task<ProdutoDTO> ObterProdutoAsync(int id)
        {
            var result = await _produtoService.ObterProdutoAsync(id);
            return _mapper.MapToResponse(result);
        }

        public async Task<int> CadastrarProdutoAsync(Produto produto)
        {
            return await _produtoService.CadastrarProdutoAsync(produto);
        }

        public async Task<bool> AlterarProdutoAsync(Produto produto, int id)
        {
            await _produtoService.AlterarProdutoAsync(produto, id);
            return true;
        }

        public async Task<bool> CancelarProdutoAsync(int codigo, bool situacao)
        {
            await _produtoService.CancelarProdutoAsync(codigo, situacao);
            return true;
        }
    }
}
