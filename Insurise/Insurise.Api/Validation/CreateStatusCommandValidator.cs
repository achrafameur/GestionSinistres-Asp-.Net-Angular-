using FluentValidation;
using Insurise.Application.Features.Common.Status.Commands.AddStatus;

namespace Insurise.Api.Validation;

public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
{
    public CreateStatusCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters!");

        RuleFor(p => p.Symbol)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters!");
    }
}