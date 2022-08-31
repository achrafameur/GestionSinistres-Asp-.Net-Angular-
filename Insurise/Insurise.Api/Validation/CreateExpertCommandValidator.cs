using FluentValidation;
using Insurise.Application.Features.Sinister.Experts.Commands.AddExpert;

namespace Insurise.Api.Validation;

public class CreateExpertCommandValidator : AbstractValidator<CreateExpertCommand>
{
    public CreateExpertCommandValidator()
    {
        RuleFor(p => p.LName)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters!");

        RuleFor(p => p.FName)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters!");

        RuleFor(p => p.Fixe)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.Tel)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.Address)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.CIN)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.Code)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.CancellationDate)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.RegistrationDate)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.BirthDate)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.Governorate)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.SexId)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.TypeExpert)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.Fax)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();
    }
}