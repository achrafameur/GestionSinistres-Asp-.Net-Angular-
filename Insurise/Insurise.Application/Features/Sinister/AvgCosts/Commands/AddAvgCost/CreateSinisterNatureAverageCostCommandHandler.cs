using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.AvgCosts.Commands.AddAvgCost;

public class CreateAvgCostCommandHandler : IRequestHandler<CreateSinisterNatureAverageCostCommand, int>
{
    private readonly IRepository<SinisterNatureAverageCost> _avgCostRepository;
    private readonly IMapper _mapper;

    public CreateAvgCostCommandHandler(IMapper mapper, IRepository<SinisterNatureAverageCost> avgCostRepository)
    {
        _mapper = mapper;
        _avgCostRepository = avgCostRepository;
    }

    public async Task<int> Handle(CreateSinisterNatureAverageCostCommand request, CancellationToken cancellationToken)
    {
        var avgCost = _mapper.Map<SinisterNatureAverageCost>(request);
        avgCost = await _avgCostRepository.AddAsync(avgCost, cancellationToken);

        return avgCost.Id;
    }
}