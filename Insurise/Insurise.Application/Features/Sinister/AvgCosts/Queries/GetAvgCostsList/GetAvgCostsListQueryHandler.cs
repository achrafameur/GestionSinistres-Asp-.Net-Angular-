using AutoMapper;
using Insurise.Application.Features.Sinister.AvgCosts.Queries.GetAvgCostDetail;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Core.Specifications.Filters.Sinister.SinisterNatureAverageCosts;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.AvgCosts.Queries.GetAvgCostsList;

public class GetAvgCostsListQueryHandler : IRequestHandler<GetAvgCostsListQuery, List<AvgCostDto>>
{
    private readonly IRepository<SinisterNatureAverageCost> _avgCostRepository;
    private readonly IMapper _mapper;

    public GetAvgCostsListQueryHandler(IMapper mapper, IRepository<SinisterNatureAverageCost> avgCostRepository)
    {
        _mapper = mapper;
        _avgCostRepository = avgCostRepository;
    }

    public async Task<List<AvgCostDto>> Handle(GetAvgCostsListQuery request, CancellationToken cancellationToken)
    {
        var filter = new SinisterNatureAverageCostsFilter
        {
            LoadChildren = true,
            Children = new List<string> {"SinisterNature"},
            IsPagingEnabled = false
        };
        var spec = new SinisterNatureAverageCostsSpec(filter);
        var allAvgCosts = await _avgCostRepository.ListAsync(spec, cancellationToken);
        return _mapper.Map<List<AvgCostDto>>(allAvgCosts);
    }
}