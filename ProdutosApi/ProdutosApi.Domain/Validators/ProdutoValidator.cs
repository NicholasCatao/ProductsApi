
using FluentValidation;
using ProdutosApi.Domain.Interfaces;
using ProdutosApi.Model;

namespace ProdutosApi.Domain.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>, IProdutoValidator
    {
        public ProdutoValidator()
        {

            RuleFor(x => x.Descricao)
                .NotEmpty()
                    .WithMessage(" Descrição deve ser informada")
                .NotNull()
                    .WithMessage(" Descrição deve ser informada");

            RuleFor(x => x.Situacao)
             .NotEmpty()
                 .WithMessage(" Situação deve ser informada")
             .NotNull()
                 .WithMessage(" Situação deve ser informada");


            RuleFor(x => x.Fabricacao)
             .NotEmpty()
                 .WithMessage(" Data de fabricação  deve ser informada")
             .NotNull()
                 .WithMessage(" Data de fabricação  deve ser informada");

            RuleFor(x => x.Validade)
           .NotEmpty()
               .WithMessage(" Data de Validade  deve ser informada")
           .NotNull()
               .WithMessage(" Data de Validade  deve ser informada");

                    RuleFor(x => x.Cnpj)
           .NotEmpty()
               .WithMessage(" Cnpj deve ser informada")
           .NotNull()
               .WithMessage(" Cnpj deve ser informada");
        }

    }
}
