using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.MandatoryDocuments.Queries.GetMandatoryDocumentList;

public class
    GetMandatoryDocumentListQueryHandler : IRequestHandler<GetMandatoryDocumentListQuery, List<MandatoryDocumentDto>>
{
    private readonly IRepository<MandatoryDocument> _MandatoryDocumentRepository;
    private readonly IMapper _mapper;

    public GetMandatoryDocumentListQueryHandler(IMapper mapper,
        IRepository<MandatoryDocument> MandatoryDocumentRepository)
    {
        _mapper = mapper;
        _MandatoryDocumentRepository = MandatoryDocumentRepository;
    }

    public async Task<List<MandatoryDocumentDto>> Handle(GetMandatoryDocumentListQuery request,
        CancellationToken cancellationToken)
    {
        var allMandatoryDocuments = await _MandatoryDocumentRepository.ListAsync(cancellationToken);
        return _mapper.Map<List<MandatoryDocumentDto>>(allMandatoryDocuments);
    }
}