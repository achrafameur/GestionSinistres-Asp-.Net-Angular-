using FluentValidation;
using Insurise.Application.Features.Common.Natures.Commands.CreateNature;

namespace Insurise.Api.Validation;

public class CreateNatureCommandValidator : AbstractValidator<CreateNatureCommand>
{
    public CreateNatureCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}