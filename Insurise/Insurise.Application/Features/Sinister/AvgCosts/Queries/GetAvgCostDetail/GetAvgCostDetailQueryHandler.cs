using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Core.Specifications.Filters.Sinister.SinisterNatureAverageCosts;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.AvgCosts.Queries.GetAvgCostDetail;

public class GetAvgCostDetailQueryHandler : IRequestHandler<GetAvgCostDetailQuery, AvgCostDto>
{
    private readonly IRepository<SinisterNatureAverageCost> _avgCostRepository;
    private readonly IMapper _mapper;

    public GetAvgCostDetailQueryHandler(IMapper mapper, IRepository<SinisterNatureAverageCost> avgCostRepository)
    {
        _mapper = mapper;
        _avgCostRepository = avgCostRepository;
    }

    public async Task<AvgCostDto> Handle(GetAvgCostDetailQuery request, CancellationToken cancellationToken)
    {
      /*  var filter = new SinisterNatureAverageCostsFilter
        {
            AvgCostId = request.AvgCostId,
            LoadChildren = true,
            Children = new List<string> {"SinisterNature"},
            IsPagingEnabled = false
        };*/
        var SinisterNatureAverageCostIdSpec = new SinisterNatureAverageCostByIdSpec(request.AvgCostId);
       /* var SinisterNatureAverageCostIdSpec = new SinisterNatureAverageCostsSpecSingleResult(filter);*/
        var SinisterNatureAverageCost = await _avgCostRepository.GetBySpecAsync(SinisterNatureAverageCostIdSpec);
        var returnedAvgCost = _mapper.Map<AvgCostDto>(SinisterNatureAverageCost);

        return returnedAvgCost;
    }
}