using FluentValidation;
using Insurise.Application.Features.Production.Proportions.Commands.AddProportion;

namespace Insurise.Api.Validation;

public class CreateProportionCommandValidator : AbstractValidator<AddProportionCommand>
{
    public CreateProportionCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 30 characters!");

        RuleFor(s => s.Occurence)
            .NotEmpty().WithMessage("{PropertyName} is required !");
    }
}