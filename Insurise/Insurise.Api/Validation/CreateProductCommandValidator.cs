using FluentValidation;
using Insurise.Application.Features.Production.Product.Commands.AddProduct;

namespace Insurise.Api.Validation;

public class CreateProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters!");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters!");
    }
}