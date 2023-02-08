using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Model
{
    public record struct Produto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int Situacao { get; set; }
        public DateTime Fabricacao { get; set; }
        public DateTime Validade { get; set; }
        public Int64 Cnpj { get; set; }
        public string? CodFornecedor { get; set; }
        public string? DescricaoFornecedor { get; set; }
    }
}
