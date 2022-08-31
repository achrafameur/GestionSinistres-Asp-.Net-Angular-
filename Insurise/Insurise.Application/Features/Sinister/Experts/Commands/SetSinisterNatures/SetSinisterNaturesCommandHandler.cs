using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Commands.SetSinisterNatures;

public class SetSinisterNaturesCommandHandler : IRequestHandler<SetSinisterNaturesCommand>
{
    private readonly IRepository<Expert> _expertRepository;
    private readonly IMapper _mapper;

    public SetSinisterNaturesCommandHandler(IMapper mapper, IRepository<Expert> ExpertRepository)
    {
        _mapper = mapper;
        _expertRepository = ExpertRepository;
    }

    public async Task<Unit> Handle(SetSinisterNaturesCommand request, CancellationToken cancellationToken)
    {
        if (request.ExpertSinisterNatures != null && request.ExpertSinisterNatures.Count > 0)
        {
            var sinisterNaturestoAdd = new List<SinisterNatureExpert>();
            var expertToUpdate = await _expertRepository.GetByIdAsync(request.expertId, cancellationToken);
            foreach (var pw in request.ExpertSinisterNatures)
            {
                var expertSinisterNature = _mapper.Map<SinisterNatureExpert>(pw);
                sinisterNaturestoAdd.Add(expertSinisterNature);
            }

            expertToUpdate.AddExpertSinisterNatures(sinisterNaturestoAdd);
            await _expertRepository.UpdateAsync(expertToUpdate, cancellationToken);
        }

        return Unit.Value;
    }
}