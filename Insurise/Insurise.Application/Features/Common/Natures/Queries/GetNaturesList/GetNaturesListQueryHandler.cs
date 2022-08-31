using AutoMapper;
using Insurise.Application.Features.Common.Natures.Queries.GetNatureDetail;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Natures.Queries.GetNaturesList;

public class GetNaturesListQueryHandler : IRequestHandler<GetNaturesListQuery, List<NatureDto>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Nature> _natureRepository;

    public GetNaturesListQueryHandler(IMapper mapper, IRepository<Nature> natureRepository)
    {
        _mapper = mapper;
        _natureRepository = natureRepository;
    }

    public async Task<List<NatureDto>> Handle(GetNaturesListQuery request, CancellationToken cancellationToken)
    {
        var natures = (await _natureRepository.ListAsync(cancellationToken)).OrderBy(x => x.Title);
        return _mapper.Map<List<NatureDto>>(natures);
    }
}