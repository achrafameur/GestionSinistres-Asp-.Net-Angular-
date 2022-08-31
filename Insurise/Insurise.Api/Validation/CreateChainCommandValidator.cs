using FluentValidation;
using Insurise.Application.Features.Common.Chains.Commands.CreateChain;

namespace Insurise.Api.Validation;

public class CreateChainCommandValidator : AbstractValidator<CreateChainCommand>
{
    public CreateChainCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}