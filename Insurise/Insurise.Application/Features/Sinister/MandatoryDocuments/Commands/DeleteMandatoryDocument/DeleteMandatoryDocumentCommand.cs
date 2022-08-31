using MediatR;

namespace Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.DeleteMandatoryDocument;

public class DeleteMandatoryDocumentCommand : IRequest
{
    public DeleteMandatoryDocumentCommand(int mandatoryDocumentId)
    {
        MandatoryDocumentId = mandatoryDocumentId;
    }

    public int MandatoryDocumentId { get; }
}