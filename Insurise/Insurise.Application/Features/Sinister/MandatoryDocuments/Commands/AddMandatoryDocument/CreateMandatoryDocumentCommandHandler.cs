using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.AddMandatoryDocument;

public class CreateMandatoryDocumentCommandHandler : IRequestHandler<CreateMandatoryDocumentCommand, int>
{
    private readonly IRepository<MandatoryDocument> _MandatoryDocumentRepository;
    private readonly IMapper _mapper;

    public CreateMandatoryDocumentCommandHandler(IMapper mapper,
        IRepository<MandatoryDocument> MandatoryDocumentRepository)
    {
        _mapper = mapper;
        _MandatoryDocumentRepository = MandatoryDocumentRepository;
    }

    public async Task<int> Handle(CreateMandatoryDocumentCommand request, CancellationToken cancellationToken)
    {
        var mandatoryDocument = _mapper.Map<MandatoryDocument>(request);
        mandatoryDocument = await _MandatoryDocumentRepository.AddAsync(mandatoryDocument, cancellationToken);

        return mandatoryDocument.Id;
    }
}