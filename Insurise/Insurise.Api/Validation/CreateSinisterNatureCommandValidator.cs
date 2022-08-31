using FluentValidation;
using Insurise.Application.Features.Sinister.SinisterNatures.Commands.AddSinisterNature;

namespace Insurise.Api.Validation;

public class CreateSinisterNatureCommandValidator : AbstractValidator<CreateSinisterNatureCommand>
{
    public CreateSinisterNatureCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();

        RuleFor(p => p.Code)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();
        RuleFor(p => p.BranchId)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();
    }
}