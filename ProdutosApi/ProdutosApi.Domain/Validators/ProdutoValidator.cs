using FluentValidation;
using ProdutosApi.Model;

namespace ProdutosApi.Domain.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleSet(ValidationRules.Incluir, () =>
            {
                ValidaCpf();
            });
        }

        private void ValidaCpf()
        {
            RuleFor(x => x.Cnpj)
            .NotEmpty().WithMessage(" CPF deve ser informado")
            .NotNull().WithMessage(" CPF deve ser informado");
        }
    }
}
