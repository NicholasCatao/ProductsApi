using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Infrastructure.InfraDb.Interfaces;
using ProdutosApi.Model;

namespace ProdutosApi.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> ObterProdutosAsync()
        {
            return await _produtoRepository.ObterProdutosAsync();
        }
        public async Task<Produto> ObterProdutoAsync(int id)
        {
            return await _produtoRepository.ObterProdutoAsync(id);
        }
        public async Task<int> CadastrarProdutoAsync(Produto produto)
            => await _produtoRepository.CadastrarProdutoAsync(produto);

        public async Task<bool> AlterarProdutoAsync(Produto produto, int id)
        {
            await _produtoRepository.AlterarProdutoAsync(produto, id);
            return true;
        }
        public async Task<bool> CancelarProdutoAsync(int codigo, bool situacao)
        {
            await _produtoRepository.CancelarProdutoAsync(codigo, situacao);
            return true;
        }
    }
}
