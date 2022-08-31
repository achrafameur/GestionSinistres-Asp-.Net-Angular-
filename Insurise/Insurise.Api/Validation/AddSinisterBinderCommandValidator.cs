using FluentValidation;
using Insurise.Application.Features.Sinister.SinisterBinders.Commands.AddSinisterBinder;

namespace Insurise.Api.Validation
{
    public class AddSinisterBinderCommandValidator : AbstractValidator<AddSinisterBinderCommand>
    {
        public AddSinisterBinderCommandValidator()
        {
            RuleFor(p => p.SinisterDate)
           .NotEmpty().WithMessage("{PropertyName} is required !")
           .NotNull();
            RuleFor(p => p.SinisterTime)
           .NotEmpty().WithMessage("{PropertyName} is required !")
           .NotNull();
            RuleFor(p => p.SinisterPlace)
           .NotEmpty().WithMessage("{PropertyName} is required !")
           .NotNull();
            RuleFor(p => p.PolicyNumber)
           .NotEmpty().WithMessage("{PropertyName} is required !")
           .NotNull();
            RuleFor(p => p.InsuredObject)
           .NotEmpty().WithMessage("{PropertyName} is required !")
           .NotNull();
            RuleFor(p => p.InsuredName)
           .NotEmpty().WithMessage("{PropertyName} is required !")
           .NotNull();
            RuleFor(p => p.Description)
           .NotEmpty().WithMessage("{PropertyName} is required !")
           .NotNull();
            RuleFor(p => p.ReclamationDate)
           .NotEmpty().WithMessage("{PropertyName} is required !")
           .NotNull();
        }
    }
}
