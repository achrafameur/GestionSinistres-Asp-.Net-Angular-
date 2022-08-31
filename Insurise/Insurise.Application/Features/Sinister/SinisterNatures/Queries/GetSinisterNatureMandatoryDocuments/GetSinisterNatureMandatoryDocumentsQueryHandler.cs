using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Core.Specifications.Filters.Sinister.SinisterNatures;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureMandatoryDocuments;

public class GetSinisterNatureMandatoryDocumentsQueryHandler : IRequestHandler<GetSinisterNatureMandatoryDocumentsQuery,
    List<GetSinisterNatureMandatoryDocumentsDto>>
{
    private readonly IRepository<SinisterNature> _SinisterNatureRepository;
    private readonly IMapper _mapper;

    public GetSinisterNatureMandatoryDocumentsQueryHandler(IMapper mapper,
        IRepository<SinisterNature> SinisterNatureRepository)
    {
        _mapper = mapper;
        _SinisterNatureRepository = SinisterNatureRepository;
    }

    public async Task<List<GetSinisterNatureMandatoryDocumentsDto>> Handle(
        GetSinisterNatureMandatoryDocumentsQuery request, CancellationToken cancellationToken)
    {
        var filter = new SinisterNatureFilter
        {
            SinisterNatureId = request.SinisterNatureId,
            LoadChildren = true,
            Children = new List<string>
                {"SinisterNaturesMandatoryDocuments", "SinisterNaturesMandatoryDocuments.MandatoryDocument"},
            IsPagingEnabled = false
        };

        var MdocumentsBySinisterNatureIdSpec = new SinisterNatureSpecSingleResult(filter);
        var MdocumentsPerSinisterNature =
            await _SinisterNatureRepository.GetBySpecAsync(MdocumentsBySinisterNatureIdSpec);

        return _mapper.Map<List<GetSinisterNatureMandatoryDocumentsDto>>(
            MdocumentsPerSinisterNature?.SinisterNaturesMandatoryDocuments.OrderBy(x => x.SinisterNature));
    }
}