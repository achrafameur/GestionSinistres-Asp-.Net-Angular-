using MediatR;

namespace Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.AddMandatoryDocument;

public class CreateMandatoryDocumentCommand : IRequest<int>
{
    public CreateMandatoryDocumentCommand(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
}