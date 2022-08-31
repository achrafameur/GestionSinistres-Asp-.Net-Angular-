using FluentValidation;
using Insurise.Application.Features.Sinister.Tiers.Commands.AddTiers;

namespace Insurise.Api.Validation;

public class CreateTiersCommandValidator : AbstractValidator<CreateTiersCommand>
{
    public CreateTiersCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters!");
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters!");
        RuleFor(p => p.Label)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters!");
        RuleFor(p => p.TaxRegistrationNumber)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters!");
        RuleFor(p => p.Phone)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();
        RuleFor(p => p.Fax)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();
    }
}