using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.DeleteMandatoryDocument;

public class DeleteMandatoryDocumentCommandHandler : IRequestHandler<DeleteMandatoryDocumentCommand>
{
    private readonly IRepository<MandatoryDocument> _mandatoryDocumentRepository;

    public DeleteMandatoryDocumentCommandHandler(IRepository<MandatoryDocument> mandatoryDocumentRepository)
    {
        _mandatoryDocumentRepository = mandatoryDocumentRepository;
    }

    public async Task<Unit> Handle(DeleteMandatoryDocumentCommand request, CancellationToken cancellationToken)
    {
        var mandatoryDocumentToDelete =
            await _mandatoryDocumentRepository.GetByIdAsync(request.MandatoryDocumentId, cancellationToken);

        if (mandatoryDocumentToDelete == null) throw new DocumentNotFoundException(request.MandatoryDocumentId);

        await _mandatoryDocumentRepository.DeleteAsync(mandatoryDocumentToDelete, cancellationToken);

        return Unit.Value;
    }
}