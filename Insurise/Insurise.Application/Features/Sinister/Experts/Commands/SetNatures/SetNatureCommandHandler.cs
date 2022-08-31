using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Commands.SetNatures;

public class SetNatureCommandHandler : IRequestHandler<SetNatureCommand>
{
    private readonly IRepository<Expert> _repository;
    private readonly IMapper _mapper;

    public SetNatureCommandHandler(IMapper mapper, IRepository<Expert> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(SetNatureCommand request, CancellationToken cancellationToken)
    {
        if (request.ExpertNatures is not {Count: > 0}) return Unit.Value;

        var first = request.ExpertNatures.FirstOrDefault();

        if (first == null) return Unit.Value;

        var expertToUpdate = await _repository.GetByIdAsync(first.ExpertId, cancellationToken);

        if (expertToUpdate == null) throw new ExpertNotFoundException(first.ExpertId);

        var expertNatures = request.ExpertNatures.Select(pw => _mapper.Map<ExpertNature>(pw)).ToList();

        expertToUpdate.AddExpertNatures(expertNatures);
        await _repository.UpdateAsync(expertToUpdate, cancellationToken);

        return Unit.Value;
    }
}