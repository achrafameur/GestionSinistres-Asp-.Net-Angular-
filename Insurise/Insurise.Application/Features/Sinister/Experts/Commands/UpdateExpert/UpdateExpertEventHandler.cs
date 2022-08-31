using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Commands.UpdateExpert;

public class UpdateExpertEventHandler : IRequestHandler<UpdateExpertCommand>
{
    private readonly IRepository<Expert> _expertRepository;
    private readonly IMapper _mapper;

    public UpdateExpertEventHandler(IMapper mapper, IRepository<Expert> expertRepository)
    {
        _mapper = mapper;
        _expertRepository = expertRepository;
    }

    public async Task<Unit> Handle(UpdateExpertCommand request, CancellationToken cancellationToken)
    {
        var expertToUpdate = await _expertRepository.GetByIdAsync(request.ExpertId, cancellationToken);

        if (expertToUpdate == null) throw new ExpertNotFoundException(request.ExpertId);

        _mapper.Map(request, expertToUpdate, typeof(UpdateExpertCommand), typeof(Expert));

        await _expertRepository.UpdateAsync(expertToUpdate, cancellationToken);

        return Unit.Value;
    }
}