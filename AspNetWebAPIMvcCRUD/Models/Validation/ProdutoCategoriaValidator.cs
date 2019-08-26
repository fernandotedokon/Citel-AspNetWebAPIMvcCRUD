using FluentValidation;
using AspNetWebAPIMvcCRUD.Models.Entities;

namespace AspNetWebAPIMvcCRUD.Models.Validation
{
    public class ProdutoCategoriaValidator : AbstractValidator<ProdutoCategoria>
    {
        public ProdutoCategoriaValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("A nome do produto deve ser informada.")
                .Length(10, 100).WithMessage("A nome do produto deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}