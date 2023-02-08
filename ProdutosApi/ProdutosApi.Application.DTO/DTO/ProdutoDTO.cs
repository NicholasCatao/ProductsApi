using ProdutosApi.Domain.Enums;

namespace ProdutosApi.Application.DTO.DTO
{
  
    public class ProdutoDTO
    {
        public Int64 Codigo { get; set; }
        public string Descricao { get; set; }
        public Situacao Situacao { get; set; }
        public DateTime Fabricacao { get; set; }
        public DateTime Validade { get; set; }
        public Int64 Cnpj { get; set; }
        public string CodFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
    }
}
