﻿using FluentValidation;
using AspNetWebAPIMvcCRUD.Models.Entities;

namespace AspNetWebAPIMvcCRUD.Models.Validation
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O nome da categoria deve ser preenchido")
                .Length(3, 100).WithMessage("O nome da categoria deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}