using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Commands.UpdateSinisterNature;

public class UpdateSinisterNatureCommandHandler : IRequestHandler<UpdateSinisterNatureCommand>
{
    private readonly IRepository<SinisterNature> _sinisterNatureRepository;
    private readonly IMapper _mapper;

    public UpdateSinisterNatureCommandHandler(IMapper mapper, IRepository<SinisterNature> sinisterNatureRepository)
    {
        _mapper = mapper;
        _sinisterNatureRepository = sinisterNatureRepository;
    }

    public async Task<Unit> Handle(UpdateSinisterNatureCommand request, CancellationToken cancellationToken)
    {
        var sinisterNatureToUpdate =
            await _sinisterNatureRepository.GetByIdAsync(request.SinisterNatureId, cancellationToken);

        if (sinisterNatureToUpdate == null) throw new SinisterNatureNotFoundException(request.SinisterNatureId);

        _mapper.Map(request, sinisterNatureToUpdate, typeof(UpdateSinisterNatureCommand), typeof(SinisterNature));

        await _sinisterNatureRepository.UpdateAsync(sinisterNatureToUpdate, cancellationToken);

        return Unit.Value;
    }
}