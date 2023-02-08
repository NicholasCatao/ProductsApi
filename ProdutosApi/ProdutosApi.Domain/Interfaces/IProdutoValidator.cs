using FluentValidation;
using ProdutosApi.Model;

namespace ProdutosApi.Domain.Interfaces
{
    public interface IProdutoValidator : IValidator<Produto>
    {
    }
}
