using FluentValidation;
using Insurise.Application.Features.Production.Tax.Commands.AddTax;

namespace Insurise.Api.Validation;

public class CreateTaxCommandValidator : AbstractValidator<CreateTaxCommand>
{
    public CreateTaxCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters!");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(30).WithMessage("{PropertyName} must not exceed 100 characters!");
    }
}