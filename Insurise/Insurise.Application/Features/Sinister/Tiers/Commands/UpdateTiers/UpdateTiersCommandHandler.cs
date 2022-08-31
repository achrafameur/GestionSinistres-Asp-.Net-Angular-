using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Tiers.Commands.UpdateTiers;

public class UpdateTiersCompanyCommandHandler : IRequestHandler<UpdateTiersCommand>
{
    private readonly IRepository<Core.Entities.Sinister.SinisterAggregate.Tiers> _repository;
    private readonly IMapper _mapper;

    public UpdateTiersCompanyCommandHandler(IMapper mapper,
        IRepository<Core.Entities.Sinister.SinisterAggregate.Tiers> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateTiersCommand request, CancellationToken cancellationToken)
    {
        var tiersToUpdate = await _repository.GetByIdAsync(request.TiersId, cancellationToken);

        if (tiersToUpdate == null) throw new TierNotFoundException(request.TiersId);

        _mapper.Map(request, tiersToUpdate, typeof(UpdateTiersCommand),
            typeof(Core.Entities.Sinister.SinisterAggregate.Tiers));

        await _repository.UpdateAsync(tiersToUpdate, cancellationToken);

        return Unit.Value;
    }
}