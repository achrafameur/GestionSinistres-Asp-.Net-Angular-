using AutoMapper;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Tiers.Commands.AddTiers;

public class CreateTiersCommandHandler : IRequestHandler<CreateTiersCommand, int>
{
    private readonly IRepository<Core.Entities.Sinister.SinisterAggregate.Tiers> _TiersRepository;
    private readonly IMapper _mapper;

    public CreateTiersCommandHandler(IMapper mapper,
        IRepository<Core.Entities.Sinister.SinisterAggregate.Tiers> TiersRepository)
    {
        _mapper = mapper;
        _TiersRepository = TiersRepository;
    }

    public async Task<int> Handle(CreateTiersCommand request, CancellationToken cancellationToken)
    {
        var tiers = _mapper.Map<Core.Entities.Sinister.SinisterAggregate.Tiers>(request);
        tiers = await _TiersRepository.AddAsync(tiers, cancellationToken);

        return tiers.Id;
    }
}