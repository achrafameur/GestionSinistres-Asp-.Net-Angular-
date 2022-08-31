using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.AvgCosts.Commands.UpdateAvgCost;

public class UpdateSinisterNatureAverageCostCommandHandler : IRequestHandler<UpdateSinisterNatureAverageCostCommand>
{
    private readonly IRepository<SinisterNatureAverageCost> _avgCostRepository;
    private readonly IMapper _mapper;

    public UpdateSinisterNatureAverageCostCommandHandler(IMapper mapper,IRepository<SinisterNatureAverageCost> avgCostRepository)
    {
        _mapper = mapper;
        _avgCostRepository = avgCostRepository;
    }

    public async Task<Unit> Handle(UpdateSinisterNatureAverageCostCommand request, CancellationToken cancellationToken)
    {
        var avgCostToUpdate = await _avgCostRepository.GetByIdAsync(request.AvgCostId, cancellationToken);

        if (avgCostToUpdate == null) throw new AverageCostNotFoundException(request.AvgCostId);

        _mapper.Map(request, avgCostToUpdate, typeof(UpdateSinisterNatureAverageCostCommand),typeof(SinisterNatureAverageCost));

        await _avgCostRepository.UpdateAsync(avgCostToUpdate, cancellationToken);

        return Unit.Value;
    }
}