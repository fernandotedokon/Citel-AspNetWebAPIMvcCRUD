using FluentValidation;
using AspNetWebAPIMvcCRUD.Models.Entities;

namespace AspNetWebAPIMvcCRUD.Models.Validation
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("O nome do produto deve ser preenchido.")
                .Length(10, 100).WithMessage("O nome do produto deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(v => v.Preco)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

        }
    }
}