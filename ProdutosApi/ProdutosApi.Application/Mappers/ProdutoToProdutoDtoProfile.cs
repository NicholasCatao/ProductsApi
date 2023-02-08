using AutoMapper;
using ProdutosApi.Application.DTO.DTO;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Model;

namespace ProdutosApi.Application.Mappers
{
    public class ProdutoToProdutoDtoProfile : IProdutoMapper
    {
        private readonly IMapper _mapper;

        public ProdutoToProdutoDtoProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoDTO>();
            });

            _mapper = config.CreateMapper();
        }

        public ProdutoDTO MapToResponse(Produto produto)
             => _mapper.Map<Produto, ProdutoDTO>(produto);
        public IEnumerable<ProdutoDTO> MapToResponse(IEnumerable<Produto> produto)
             => _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoDTO>>(produto);
    }
}
