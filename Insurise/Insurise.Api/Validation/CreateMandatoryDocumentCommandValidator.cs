using FluentValidation;
using Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.AddMandatoryDocument;

namespace Insurise.Api.Validation;

public class CreateMandatoryDocumentCommandValidator : AbstractValidator<CreateMandatoryDocumentCommand>
{
    public CreateMandatoryDocumentCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required !")
            .NotNull();
    }
}