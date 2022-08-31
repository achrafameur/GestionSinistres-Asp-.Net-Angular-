using FluentValidation;
using Insurise.Application.Features.Common.Feature.Commands.Add;

namespace Insurise.Api.Validation;

public class CreateCharacteristicCommandValidator : AbstractValidator<AddFeatureCommand>
{
    public CreateCharacteristicCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 30 characters!");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 100 characters!");


        RuleFor(p => p.Symbol)
            .NotNull()
            .MaximumLength(30).WithMessage("{PropertyName} must not exceed 100 characters!");
        
     
    }
}