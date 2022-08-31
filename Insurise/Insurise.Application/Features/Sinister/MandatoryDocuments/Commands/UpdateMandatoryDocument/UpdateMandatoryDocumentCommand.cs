using MediatR;

namespace Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.UpdateMandatoryDocument;

public class UpdateMandatoryDocumentCommand : IRequest
{
    public UpdateMandatoryDocumentCommand(int mandatoryDocumentId, string title)
    {
        MandatoryDocumentId = mandatoryDocumentId;
        Title = title;
    }

    public int MandatoryDocumentId { get; set; }
    public string Title { get; set; }
}