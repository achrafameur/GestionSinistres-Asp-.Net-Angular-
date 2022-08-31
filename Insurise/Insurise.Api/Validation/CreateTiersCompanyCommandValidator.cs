using FluentValidation;
using Insurise.Application.Features.Sinister.TiersCompanies.Commands.AddTiersCompany;

namespace Insurise.Api.Validation;

public class CreateTiersCompanyCommandValidator : AbstractValidator<CreateTiersCompanyCommand>
{
    public CreateTiersCompanyCommandValidator()
    {
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();
        RuleFor(p => p.Label)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters!");
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
        RuleFor(p => p.Address)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();
    }
}