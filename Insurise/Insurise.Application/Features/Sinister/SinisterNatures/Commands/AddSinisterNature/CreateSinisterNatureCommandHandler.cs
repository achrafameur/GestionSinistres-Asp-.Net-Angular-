using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Commands.AddSinisterNature;

public class CreateSinisterNatureCommandHandler : IRequestHandler<CreateSinisterNatureCommand, int>
{
    private readonly IRepository<SinisterNature> _sinisterNatureRepository;
    private readonly IMapper _mapper;

    public CreateSinisterNatureCommandHandler(IMapper mapper, IRepository<SinisterNature> sinisterNatureRepository)
    {
        _mapper = mapper;
        _sinisterNatureRepository = sinisterNatureRepository;
    }

    public async Task<int> Handle(CreateSinisterNatureCommand request, CancellationToken cancellationToken)
    {
        var sinisterNature = _mapper.Map<SinisterNature>(request);
        sinisterNature = await _sinisterNatureRepository.AddAsync(sinisterNature, cancellationToken);

        return sinisterNature.Id;
    }
}