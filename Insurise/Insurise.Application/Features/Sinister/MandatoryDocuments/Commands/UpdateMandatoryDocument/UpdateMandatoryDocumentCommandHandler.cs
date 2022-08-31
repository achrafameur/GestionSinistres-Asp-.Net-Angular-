using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.UpdateMandatoryDocument;

public class UpdateMandatoryDocumentCommandHandler : IRequestHandler<UpdateMandatoryDocumentCommand>
{
    private readonly IRepository<MandatoryDocument> _mandatoryDocumentRepository;
    private readonly IMapper _mapper;

    public UpdateMandatoryDocumentCommandHandler(IMapper mapper,
        IRepository<MandatoryDocument> mandatoryDocumentRepository)
    {
        _mapper = mapper;
        _mandatoryDocumentRepository = mandatoryDocumentRepository;
    }

    public async Task<Unit> Handle(UpdateMandatoryDocumentCommand request, CancellationToken cancellationToken)
    {
        var documentToUpdate =
            await _mandatoryDocumentRepository.GetByIdAsync(request.MandatoryDocumentId, cancellationToken);

        if (documentToUpdate == null) throw new DocumentNotFoundException(request.MandatoryDocumentId);

        _mapper.Map(request, documentToUpdate, typeof(UpdateMandatoryDocumentCommand), typeof(MandatoryDocument));

        await _mandatoryDocumentRepository.UpdateAsync(documentToUpdate, cancellationToken);

        return Unit.Value;
    }
}