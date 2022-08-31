using FluentValidation;
using Insurise.Application.Features.Sinister.AvgCosts.Commands.AddAvgCost;

namespace Insurise.Api.Validation;

public class CreateSinisterNatureAverageCostCommandValidator : AbstractValidator<CreateSinisterNatureAverageCostCommand>
{
    public CreateSinisterNatureAverageCostCommandValidator()
    {
        RuleFor(p => p.AverageCost)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.DateStart)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.DateEnd)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();
    }
}