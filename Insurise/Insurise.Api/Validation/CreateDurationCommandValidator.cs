using FluentValidation;
using Insurise.Application.Features.Production.Durations.Commands.AddDuration;

namespace Insurise.Api.Validation;

public class CreateDurationCommandValidator : AbstractValidator<CreateDurationCommand>
{
    public CreateDurationCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 30 characters!");
        RuleFor(p => p.Type)
            .NotNull();
        RuleFor(p => p.EndDate)
            .NotNull();
        RuleFor(p => p.StartDate)
            .NotNull();
        RuleFor(p => p.Coefficient)
            .NotNull();
        RuleFor(p => p.Renewable)
            .NotNull();
    }
}