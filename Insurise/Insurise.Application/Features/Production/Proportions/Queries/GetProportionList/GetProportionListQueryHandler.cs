using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Proportions.Queries.GetProportionList;

public class GetProportionListQueryHandler : IRequestHandler<GetProportionListQuery, List<ProportionDto>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Proportion> _proportionRepository;

    public GetProportionListQueryHandler(IMapper mapper, IRepository<Proportion> proportionRepository)
    {
        _mapper = mapper;
        _proportionRepository = proportionRepository;
    }

    public async Task<List<ProportionDto>> Handle(GetProportionListQuery request,
        CancellationToken cancellationToken)
    {
        var proportions = (await _proportionRepository.ListAsync(cancellationToken)).OrderBy(x => x.Title);
        return _mapper.Map<List<ProportionDto>>(proportions);
    }
}