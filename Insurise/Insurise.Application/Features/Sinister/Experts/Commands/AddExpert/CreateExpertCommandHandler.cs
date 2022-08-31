using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Commands.AddExpert;

public class CreateExpertCommandHandler : IRequestHandler<CreateExpertCommand, int>
{
    private readonly IRepository<Expert> _expertRepository;
    private readonly IMapper _mapper;

    public CreateExpertCommandHandler(IMapper mapper, IRepository<Expert> expertRepository)
    {
        _mapper = mapper;
        _expertRepository = expertRepository;
    }

    public async Task<int> Handle(CreateExpertCommand request, CancellationToken cancellationToken)
    {
        var expert = _mapper.Map<Expert>(request);
        expert = await _expertRepository.AddAsync(expert, cancellationToken);

        return expert.Id;
    }
}