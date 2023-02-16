using Newtonsoft.Json;
using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Infrastructure.InfraDb.Interfaces;
using ProdutosApi.Model;
using System.Collections.Generic;

namespace ProdutosApi.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICacheService _cache;

        public ProdutoService(IProdutoRepository produtoRepository, ICacheService cache)
        {
            _produtoRepository = produtoRepository;
            _cache = cache;
        }

        public async Task<IEnumerable<Produto>> ObterProdutosAsync()
        {
            var response = new List<Produto>();

            var cacheData = await _cache.GetAsync("produtos");

            if (string.IsNullOrWhiteSpace(cacheData) is false)
            {
                response.AddRange(JsonConvert.DeserializeObject<List<Produto>>(cacheData));
                return response;
            }
            else
            {
                response.AddRange(await _produtoRepository.ObterProdutosAsync());
            }

            await _cache.SetAsync("produtos", JsonConvert.SerializeObject(response));

            return response;
        }
        public async Task<Produto> ObterProdutoAsync(int id)
        {
            return await _produtoRepository.ObterProdutoAsync(id);
        }
        public async Task<int> CadastrarProdutoAsync(Produto produto)
        {
            return await _produtoRepository.CadastrarProdutoAsync(produto);
        }

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
