using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("{ProductName} is required!")
                .NotNull()
                .MaximumLength(250).WithMessage("{ProductName} must not exceed 250 characters.");

            RuleFor(p => p.VatRate)
                .NotEmpty().WithMessage("{VatRate} is required!")
                .NotNull()
                .GreaterThan(0);
        }
    }
}
