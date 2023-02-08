using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Model
{
    public record struct Produto
    {
        [Required]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int Situacao { get; set; }
        public DateTime Fabricacao { get; set; }
        public DateTime Validade { get; set; }
        [Required]
        public Int64 Cnpj { get; set; }
        [Required]
        public string CodFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
    }
}
